﻿/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

#if AWS_ASYNC_API
using System.Threading.Tasks;
#endif

using Amazon.Internal;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.Util;
using Amazon.S3.Internal;
using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using Amazon.S3.Util;
using Amazon.Util.Internal;

namespace Amazon.S3
{
    public partial class AmazonS3Client : AmazonServiceClient, IAmazonS3
    {
        /// <summary>
        /// Specialize the initialize of the client.
        /// </summary>
        protected override void Initialize()
        {
            var clientConfig = this.Config as ClientConfig;
            if (clientConfig != null)
            {
                clientConfig.ResignRetries = true;
            }
            base.Initialize();
        }

        /// <summary>
        /// Create a signed URL allowing access to a resource that would 
        /// usually require authentication.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When using query string authentication you create a query,
        /// specify an expiration time for the query, sign it with your
        /// signature, place the data in an HTTP request, and distribute
        /// the request to a user or embed the request in a web page.
        /// </para>
        /// <para>
        /// A PreSigned URL can be generated for GET, PUT, DELETE and HEAD
        /// operations on your bucketName, keys, and versions.
        /// </para>
        /// </remarks>
        /// <param name="request">The GetPreSignedUrlRequest that defines the
        /// parameters of the operation.</param>
        /// <param name="useSigV2Fallback">determines if signing will fall back to SigV2 if the
        /// signing region is us-east-1</param>
        /// <returns>A string that is the signed http request.</returns>
        /// <exception cref="T:System.ArgumentException" />
        /// <exception cref="T:System.ArgumentNullException" />
        internal string GetPreSignedURLInternal(GetPreSignedUrlRequest request, bool useSigV2Fallback = true)
        {
            if (Credentials == null)
                throw new AmazonS3Exception("Credentials must be specified, cannot call method anonymously");

            if (request == null)
                throw new ArgumentNullException("request", "The PreSignedUrlRequest specified is null!");

            if (!request.IsSetExpires())
                throw new InvalidOperationException("The Expires specified is null!");

            var signatureVersionToUse = AWSConfigsS3.UseSignatureVersion4 ? SignatureVersion.SigV4 : SignatureVersion.SigV2;

            Arn arn;
            string accessPoint;
            if (Arn.TryParse(request.BucketName, out arn) && 
                (arn.TryParseAccessPoint(out accessPoint) || arn.IsOutpostArn()))
            {
                signatureVersionToUse = SignatureVersion.SigV4;

                if (arn.IsMRAPArn())
                {
                    signatureVersionToUse = SignatureVersion.SigV4a;
                }
            }
            else
            {
                var region = AWS4Signer.DetermineSigningRegion(Config, "s3", alternateEndpoint: null, request: null);
                if (signatureVersionToUse == SignatureVersion.SigV4 && string.IsNullOrEmpty(region))
                    throw new InvalidOperationException("To use AWS4 signing, a region must be specified in the client configuration using the AuthenticationRegion or Region properties, or be determinable from the service URL.");

                RegionEndpoint endpoint = RegionEndpoint.GetBySystemName(region);
                var s3SignatureVersionOverride = endpoint.GetEndpointForService("s3", Config.ToGetEndpointForServiceOptions()).SignatureVersionOverride;
                if (s3SignatureVersionOverride == "4" || s3SignatureVersionOverride == null)
                {
                    signatureVersionToUse = SignatureVersion.SigV4;
                }

                var fallbackToSigV2 = useSigV2Fallback && !AWSConfigsS3.UseSigV4SetExplicitly;
                if (endpoint?.SystemName == RegionEndpoint.USEast1.SystemName && fallbackToSigV2)
                {
                    signatureVersionToUse = SignatureVersion.SigV2;
                }

                // If the expiration is longer than SigV4 will allow then automatically use SigV2 instead.
                // But only if the region we're signing for allows SigV2.
                if (signatureVersionToUse == SignatureVersion.SigV4)
                {
                    var secondsUntilExpiration = GetSecondsUntilExpiration(this.Config, request, signatureVersionToUse);

                    if (secondsUntilExpiration > AWS4PreSignedUrlSigner.MaxAWS4PreSignedUrlExpiry &&
                        s3SignatureVersionOverride == "2")
                    {
                        signatureVersionToUse = SignatureVersion.SigV2;
                    }
                }
            }


            var immutableCredentials = Credentials.GetCredentials();
            var irequest = Marshall(this.Config, request, immutableCredentials.AccessKey, immutableCredentials.Token, signatureVersionToUse);

            irequest.Endpoint = EndpointResolver.DetermineEndpoint(this.Config, irequest);

            var context = new Amazon.Runtime.Internal.ExecutionContext(new Amazon.Runtime.Internal.RequestContext(true, new NullSigner()) { Request = irequest, ClientConfig = this.Config }, null);
            AmazonS3PostMarshallHandler.ProcessRequestHandlers(context);

            var metrics = new RequestMetrics();
            string result;
            string authorization;

            switch (signatureVersionToUse)
            {
                case SignatureVersion.SigV4a:
                    var aws4aSigner = new AWS4aSignerCRTWrapper();
                    var signingResult4a = aws4aSigner.Presign4a(irequest,
                                                            Config,
                                                            metrics,
                                                            immutableCredentials,
                                                            "s3",
                                                            arn.IsMRAPArn() ? "*" : "");
                    result = signingResult4a.PresignedUri;
                    break;
                case SignatureVersion.SigV4:
                    var aws4Signer = new AWS4PreSignedUrlSigner();
                    var signingResult4 = aws4Signer.SignRequest(irequest,
                                                           Config,
                                                           metrics,
                                                           immutableCredentials.AccessKey,
                                                           immutableCredentials.SecretKey);
                    authorization = "&" + signingResult4.ForQueryParameters;
                    result = ComposeUrl(irequest).AbsoluteUri + authorization;
                    break;
                default: // SigV2
                    Amazon.S3.Internal.S3Signer.SignRequest(irequest, metrics, immutableCredentials.AccessKey, immutableCredentials.SecretKey);
                    authorization = irequest.Headers[HeaderKeys.AuthorizationHeader];
                    authorization = authorization.Substring(authorization.IndexOf(":", StringComparison.Ordinal) + 1);
                    authorization = "&Signature=" + AmazonS3Util.UrlEncode(authorization, false);
                    result = ComposeUrl(irequest).AbsoluteUri + authorization;
                    break;
            }

            Protocol protocol = DetermineProtocol();
            if (request.Protocol != protocol)
            {
                switch (protocol)
                {
                    case Protocol.HTTP:
                        result = result.Replace("http://", "https://");
                        break;
                    case Protocol.HTTPS:
                        result = result.Replace("https://", "http://");
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// Marshalls the parameters for a presigned url for a preferred signing protocol.
        /// </summary>
        /// <param name="config">service client configuration</param>
        /// <param name="getPreSignedUrlRequest"></param>
        /// <param name="accessKey"></param>
        /// <param name="token"></param>
        /// <param name="signatureVersion">Signature version to use.
        /// If AWS4 signing will be used and if the expiry period in the request exceeds the
        /// maximum allowed for AWS4 (one week), an ArgumentException is thrown.
        /// </param>
        /// <returns>Internal request</returns>
        private static IRequest Marshall(IClientConfig config, 
                                         GetPreSignedUrlRequest getPreSignedUrlRequest,
                                         string accessKey,
                                         string token,
                                         SignatureVersion signatureVersion)
        {
            IRequest request = new DefaultRequest(getPreSignedUrlRequest, "AmazonS3");
            request.HttpMethod = getPreSignedUrlRequest.Verb.ToString();

            var headers = getPreSignedUrlRequest.Headers;
            foreach (var key in headers.Keys)
                request.Headers[key] = headers[key];

            AmazonS3Util.SetMetadataHeaders(request, getPreSignedUrlRequest.Metadata);

            if (getPreSignedUrlRequest.ServerSideEncryptionMethod != null && getPreSignedUrlRequest.ServerSideEncryptionMethod != ServerSideEncryptionMethod.None)
                request.Headers.Add(HeaderKeys.XAmzServerSideEncryptionHeader, S3Transforms.ToStringValue(getPreSignedUrlRequest.ServerSideEncryptionMethod));
            if (getPreSignedUrlRequest.IsSetServerSideEncryptionCustomerMethod())
                request.Headers.Add(HeaderKeys.XAmzSSECustomerAlgorithmHeader, getPreSignedUrlRequest.ServerSideEncryptionCustomerMethod);
            if (getPreSignedUrlRequest.IsSetServerSideEncryptionKeyManagementServiceKeyId())
                request.Headers.Add(HeaderKeys.XAmzServerSideEncryptionAwsKmsKeyIdHeader, getPreSignedUrlRequest.ServerSideEncryptionKeyManagementServiceKeyId);

            if (getPreSignedUrlRequest.IsSetRequestPayer() && getPreSignedUrlRequest.RequestPayer == RequestPayer.Requester)
                request.Parameters.Add("x-amz-request-payer", RequestPayer.Requester.Value);

            var queryParameters = request.Parameters;

            var uriResourcePath = new StringBuilder("/");
            if (!string.IsNullOrEmpty(getPreSignedUrlRequest.BucketName))
                uriResourcePath.Append(S3Transforms.ToStringValue(getPreSignedUrlRequest.BucketName));
            if (!string.IsNullOrEmpty(getPreSignedUrlRequest.Key))
            {
                if (uriResourcePath.Length > 1)
                    uriResourcePath.Append("/");
                uriResourcePath.Append(S3Transforms.ToStringValue(getPreSignedUrlRequest.Key));
            }

            var expires = GetSecondsUntilExpiration(config, getPreSignedUrlRequest, signatureVersion);

            if ((signatureVersion == SignatureVersion.SigV4 || signatureVersion == SignatureVersion.SigV4a)
                    && expires > AWS4PreSignedUrlSigner.MaxAWS4PreSignedUrlExpiry)
            {
                var msg = string.Format(CultureInfo.InvariantCulture, "The maximum expiry period for a presigned url using AWS4 signing is {0} seconds",
                                        AWS4PreSignedUrlSigner.MaxAWS4PreSignedUrlExpiry);
                throw new ArgumentException(msg);
            }

            if (signatureVersion == SignatureVersion.SigV2)
            {
                queryParameters.Add("Expires", expires.ToString(CultureInfo.InvariantCulture));
                queryParameters.Add("AWSAccessKeyId", accessKey);
                if (!string.IsNullOrEmpty(token))
                    queryParameters.Add("x-amz-security-token", token);
            }
            else // SigV4 or SigV4a
            {
                queryParameters.Add(HeaderKeys.XAmzExpires, expires.ToString(CultureInfo.InvariantCulture));
                if (!string.IsNullOrEmpty(token))
                    queryParameters.Add("X-Amz-Security-Token", token);
            }

            if (getPreSignedUrlRequest.IsSetVersionId())
                request.AddSubResource("versionId", S3Transforms.ToStringValue(getPreSignedUrlRequest.VersionId));
            if (getPreSignedUrlRequest.IsSetUploadId())
                request.AddSubResource("uploadId", S3Transforms.ToStringValue(getPreSignedUrlRequest.UploadId));
            if (getPreSignedUrlRequest.IsSetPartNumber())
                request.AddSubResource("partNumber", S3Transforms.ToStringValue(getPreSignedUrlRequest.PartNumber));

            var responseHeaderOverrides = getPreSignedUrlRequest.ResponseHeaderOverrides;
            if (!string.IsNullOrEmpty(responseHeaderOverrides.CacheControl))
                queryParameters.Add("response-cache-control", responseHeaderOverrides.CacheControl);
            if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentType))
                queryParameters.Add("response-content-type", responseHeaderOverrides.ContentType);
            if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentLanguage))
                queryParameters.Add("response-content-language", responseHeaderOverrides.ContentLanguage);
            if (!string.IsNullOrEmpty(responseHeaderOverrides.Expires))
                queryParameters.Add("response-expires", responseHeaderOverrides.Expires);
            if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentDisposition))
                queryParameters.Add("response-content-disposition", responseHeaderOverrides.ContentDisposition);
            if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentEncoding))
                queryParameters.Add("response-content-encoding", responseHeaderOverrides.ContentEncoding);

            // Add custom parameters to be included and signed
            foreach (string k in getPreSignedUrlRequest.Parameters.Keys)
                queryParameters.Add(k, getPreSignedUrlRequest.Parameters[k]);

            request.ResourcePath = uriResourcePath.ToString();
            request.UseQueryString = true;

            return request;
        }

        private static long GetSecondsUntilExpiration(IClientConfig config, GetPreSignedUrlRequest request, SignatureVersion signatureVersion)
        {
            DateTime baselineTime;
            if (signatureVersion == SignatureVersion.SigV2)
            {
                baselineTime = new DateTime(1970, 1, 1);
            }
            else // SigV4 or SigV4a
            {
                baselineTime = config.CorrectedUtcNow;
            }
            return Convert.ToInt64((request.Expires.ToUniversalTime() - baselineTime).TotalSeconds);
        }

        private Protocol DetermineProtocol()
        {
            string serviceUrl = Config.DetermineServiceURL();
            Protocol protocol = serviceUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase) ? Protocol.HTTPS : Protocol.HTTP;
            return protocol;
        }

        internal static void CleanupRequest(AmazonWebServiceRequest request)
        {
            var putObjectRequest = request as PutObjectRequest;
            if (putObjectRequest != null)
            {
                if (putObjectRequest.InputStream != null
                    && (!string.IsNullOrEmpty(putObjectRequest.FilePath) || putObjectRequest.AutoCloseStream))
                {
                    putObjectRequest.InputStream.Dispose();
                }

                // Set the input stream to null since it was created during the request to represent the filepath or content body
                if (!string.IsNullOrEmpty(putObjectRequest.FilePath) || !string.IsNullOrEmpty(putObjectRequest.ContentBody))
                {
                    putObjectRequest.InputStream = null;
                }
            }

            var uploadPartRequest = request as UploadPartRequest;
            if (uploadPartRequest != null)
            {
                // FilePath was set, so we created the underlying stream, so we must close it
                if (uploadPartRequest.IsSetFilePath() && uploadPartRequest.InputStream != null)
                {
                    uploadPartRequest.InputStream.Dispose();
                }

                if (uploadPartRequest.IsSetFilePath())
                    uploadPartRequest.InputStream = null;
            }
        }

                internal void ConfigureProxy(HttpWebRequest httpRequest)
        {
#if BCL
            if (!string.IsNullOrEmpty(Config.ProxyHost) && Config.ProxyPort != -1)
            {
                WebProxy proxy = new WebProxy(Config.ProxyHost, Config.ProxyPort);
                httpRequest.Proxy = proxy;
            }
#elif NETSTANDARD
            httpRequest.Proxy = Config.GetWebProxy();
#endif
            if (httpRequest.Proxy != null && Config.ProxyCredentials != null)
            {
                httpRequest.Proxy.Credentials = Config.ProxyCredentials;
            }
        }


    #region GetPreSignedURL

        /// <summary>
        /// Create a signed URL allowing access to a resource that would 
        /// usually require authentication.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When using query string authentication you create a query,
        /// specify an expiration time for the query, sign it with your
        /// signature, place the data in an HTTP request, and distribute
        /// the request to a user or embed the request in a web page.
        /// </para>
        /// <para>
        /// A PreSigned URL can be generated for GET, PUT, DELETE and HEAD
        /// operations on your bucketName, keys, and versions.
        /// </para>
        /// </remarks>
        /// <param name="request">The GetPreSignedUrlRequest that defines the
        /// parameters of the operation.</param>
        /// <returns>A string that is the signed http request.</returns>
        /// <exception cref="T:System.ArgumentException" />
        /// <exception cref="T:System.ArgumentNullException" />
        public string GetPreSignedURL(GetPreSignedUrlRequest request)
        {
            return GetPreSignedURLInternal(request);
        }

        #endregion

        #region ICoreAmazonS3 Implementation

        string ICoreAmazonS3.GeneratePreSignedURL(string bucketName, string objectKey, DateTime expiration, IDictionary<string, object> additionalProperties)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                Expires = expiration
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);


            return this.GetPreSignedURL(request);
        }

#if AWS_APM_API

        IAsyncResult ICoreAmazonS3.BeginDelete(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, AsyncCallback callback, object state)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);

            return this.BeginDeleteObject(request, callback, state);
        }

        void ICoreAmazonS3.EndDelete(IAsyncResult result)
        {
            this.EndDeleteObject(result);
        }

        IAsyncResult ICoreAmazonS3.BeginUploadObjectFromStream(string bucketName, string objectKey, Stream stream, IDictionary<string, object> additionalProperties, AsyncCallback callback, object state)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);
            var request = new Amazon.S3.Transfer.TransferUtilityUploadRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = stream
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);

            return transfer.BeginUpload(request, callback, state);
        }

        void ICoreAmazonS3.EndUploadObjectFromStream(IAsyncResult result)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);
            transfer.EndUpload(result);
        }

        IAsyncResult ICoreAmazonS3.BeginUploadObjectFromFilePath(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, AsyncCallback callback, object state)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);
            var request = new Amazon.S3.Transfer.TransferUtilityUploadRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                FilePath = filepath
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);

            return transfer.BeginUpload(request, callback, state);
        }

        void ICoreAmazonS3.EndUploadObjectFromFilePath(IAsyncResult result)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);
            transfer.EndUpload(result);
        }

        IAsyncResult ICoreAmazonS3.BeginDownloadToFilePath(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, AsyncCallback callback, object state)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);

            var request = new Amazon.S3.Transfer.TransferUtilityDownloadRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                FilePath = filepath
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);

            return transfer.BeginDownload(request, callback, state);
        }

        void ICoreAmazonS3.EndDownloadToFilePath(IAsyncResult result)
        {
            var transfer = new Amazon.S3.Transfer.TransferUtility(this);
            transfer.EndDownload(result);
        }

        IAsyncResult ICoreAmazonS3.BeginGetObjectStream(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, AsyncCallback callback, object state)
        {
            var request = new GetObjectRequest()
            {
                BucketName = bucketName,
                Key = objectKey
            };
            InternalSDKUtils.ApplyValues(request, additionalProperties);

            return this.BeginGetObject(request, callback, state);
        }

        Stream ICoreAmazonS3.EndGetObjectStream(IAsyncResult result)
        {
            return this.EndGetObject(result).ResponseStream;
        }
#endif
#endregion
    }
}
