/*
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

/*
 * Do not modify this file. This file is generated from the kinesisanalyticsv2-2018-05-23.normal.json service model.
 */


using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Amazon.Runtime;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.KinesisAnalyticsV2
{
    /// <summary>
    /// Interface for accessing KinesisAnalyticsV2
    ///
    /// Amazon Kinesis Data Analytics is a fully managed service that you can use to process
    /// and analyze streaming data using SQL or Java. The service enables you to quickly author
    /// and run SQL or Java code against streaming sources to perform time series analytics,
    /// feed real-time dashboards, and create real-time metrics.
    /// </summary>
    public partial interface IAmazonKinesisAnalyticsV2 : IAmazonService, IDisposable
    {
                
        #region  AddApplicationCloudWatchLoggingOption



        /// <summary>
        /// Adds an Amazon CloudWatch log stream to monitor application configuration errors.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationCloudWatchLoggingOption service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationCloudWatchLoggingOption service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationCloudWatchLoggingOption">REST API Reference for AddApplicationCloudWatchLoggingOption Operation</seealso>
        Task<AddApplicationCloudWatchLoggingOptionResponse> AddApplicationCloudWatchLoggingOptionAsync(AddApplicationCloudWatchLoggingOptionRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  AddApplicationInput



        /// <summary>
        /// Adds a streaming source to your SQL-based Amazon Kinesis Data Analytics application.
        /// 
        /// 
        ///  
        /// <para>
        /// You can add a streaming source when you create an application, or you can use this
        /// operation to add a streaming source after you create an application. For more information,
        /// see <a>CreateApplication</a>.
        /// </para>
        ///  
        /// <para>
        /// Any configuration update, including adding a streaming source using this operation,
        /// results in a new version of the application. You can use the <a>DescribeApplication</a>
        /// operation to find the current application version. 
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationInput service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationInput service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.CodeValidationException">
        /// The user-provided application code (query) is not valid. This can be a simple syntax
        /// error.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationInput">REST API Reference for AddApplicationInput Operation</seealso>
        Task<AddApplicationInputResponse> AddApplicationInputAsync(AddApplicationInputRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  AddApplicationInputProcessingConfiguration



        /// <summary>
        /// Adds an <a>InputProcessingConfiguration</a> to an SQL-based Kinesis Data Analytics
        /// application. An input processor pre-processes records on the input stream before the
        /// application's SQL code executes. Currently, the only input processor available is
        /// <a href="https://aws.amazon.com/documentation/lambda/">AWS Lambda</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationInputProcessingConfiguration service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationInputProcessingConfiguration service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationInputProcessingConfiguration">REST API Reference for AddApplicationInputProcessingConfiguration Operation</seealso>
        Task<AddApplicationInputProcessingConfigurationResponse> AddApplicationInputProcessingConfigurationAsync(AddApplicationInputProcessingConfigurationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  AddApplicationOutput



        /// <summary>
        /// Adds an external destination to your SQL-based Amazon Kinesis Data Analytics application.
        /// 
        ///  
        /// <para>
        /// If you want Kinesis Data Analytics to deliver data from an in-application stream within
        /// your application to an external destination (such as an Kinesis data stream, a Kinesis
        /// Data Firehose delivery stream, or an AWS Lambda function), you add the relevant configuration
        /// to your application using this operation. You can configure one or more outputs for
        /// your application. Each output configuration maps an in-application stream and an external
        /// destination.
        /// </para>
        ///  
        /// <para>
        ///  You can use one of the output configurations to deliver data from your in-application
        /// error stream to an external destination so that you can analyze the errors. 
        /// </para>
        ///  
        /// <para>
        ///  Any configuration update, including adding a streaming source using this operation,
        /// results in a new version of the application. You can use the <a>DescribeApplication</a>
        /// operation to find the current application version.
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationOutput service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationOutput service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationOutput">REST API Reference for AddApplicationOutput Operation</seealso>
        Task<AddApplicationOutputResponse> AddApplicationOutputAsync(AddApplicationOutputRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  AddApplicationReferenceDataSource



        /// <summary>
        /// Adds a reference data source to an existing SQL-based Amazon Kinesis Data Analytics
        /// application.
        /// 
        ///  
        /// <para>
        /// Kinesis Data Analytics reads reference data (that is, an Amazon S3 object) and creates
        /// an in-application table within your application. In the request, you provide the source
        /// (S3 bucket name and object key name), name of the in-application table to create,
        /// and the necessary mapping information that describes how data in an Amazon S3 object
        /// maps to columns in the resulting in-application table.
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationReferenceDataSource service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationReferenceDataSource service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationReferenceDataSource">REST API Reference for AddApplicationReferenceDataSource Operation</seealso>
        Task<AddApplicationReferenceDataSourceResponse> AddApplicationReferenceDataSourceAsync(AddApplicationReferenceDataSourceRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  AddApplicationVpcConfiguration



        /// <summary>
        /// Adds a Virtual Private Cloud (VPC) configuration to the application. Applications
        /// can use VPCs to store and access resources securely.
        /// 
        ///  
        /// <para>
        /// Note the following about VPC configurations for Kinesis Data Analytics applications:
        /// </para>
        ///  <ul> <li> 
        /// <para>
        /// VPC configurations are not supported for SQL applications.
        /// </para>
        ///  </li> <li> 
        /// <para>
        /// When a VPC is added to a Kinesis Data Analytics application, the application can no
        /// longer be accessed from the Internet directly. To enable Internet access to the application,
        /// add an Internet gateway to your VPC.
        /// </para>
        ///  </li> </ul>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the AddApplicationVpcConfiguration service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the AddApplicationVpcConfiguration service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/AddApplicationVpcConfiguration">REST API Reference for AddApplicationVpcConfiguration Operation</seealso>
        Task<AddApplicationVpcConfigurationResponse> AddApplicationVpcConfigurationAsync(AddApplicationVpcConfigurationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  CreateApplication



        /// <summary>
        /// Creates an Amazon Kinesis Data Analytics application. For information about creating
        /// a Kinesis Data Analytics application, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/getting-started.html">Creating
        /// an Application</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the CreateApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the CreateApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.CodeValidationException">
        /// The user-provided application code (query) is not valid. This can be a simple syntax
        /// error.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.LimitExceededException">
        /// The number of allowed resources has been exceeded.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.TooManyTagsException">
        /// Application created with too many tags, or too many tags added to an application.
        /// Note that the maximum number of application tags includes system tags. The maximum
        /// number of user-defined application tags is 50.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/CreateApplication">REST API Reference for CreateApplication Operation</seealso>
        Task<CreateApplicationResponse> CreateApplicationAsync(CreateApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  CreateApplicationSnapshot



        /// <summary>
        /// Creates a snapshot of the application's state data.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the CreateApplicationSnapshot service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the CreateApplicationSnapshot service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.LimitExceededException">
        /// The number of allowed resources has been exceeded.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.UnsupportedOperationException">
        /// The request was rejected because a specified parameter is not supported or a specified
        /// resource is not valid for this operation.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/CreateApplicationSnapshot">REST API Reference for CreateApplicationSnapshot Operation</seealso>
        Task<CreateApplicationSnapshotResponse> CreateApplicationSnapshotAsync(CreateApplicationSnapshotRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplication



        /// <summary>
        /// Deletes the specified application. Kinesis Data Analytics halts application execution
        /// and deletes the application.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplication">REST API Reference for DeleteApplication Operation</seealso>
        Task<DeleteApplicationResponse> DeleteApplicationAsync(DeleteApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationCloudWatchLoggingOption



        /// <summary>
        /// Deletes an Amazon CloudWatch log stream from an Amazon Kinesis Data Analytics application.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationCloudWatchLoggingOption service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationCloudWatchLoggingOption service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationCloudWatchLoggingOption">REST API Reference for DeleteApplicationCloudWatchLoggingOption Operation</seealso>
        Task<DeleteApplicationCloudWatchLoggingOptionResponse> DeleteApplicationCloudWatchLoggingOptionAsync(DeleteApplicationCloudWatchLoggingOptionRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationInputProcessingConfiguration



        /// <summary>
        /// Deletes an <a>InputProcessingConfiguration</a> from an input.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationInputProcessingConfiguration service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationInputProcessingConfiguration service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationInputProcessingConfiguration">REST API Reference for DeleteApplicationInputProcessingConfiguration Operation</seealso>
        Task<DeleteApplicationInputProcessingConfigurationResponse> DeleteApplicationInputProcessingConfigurationAsync(DeleteApplicationInputProcessingConfigurationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationOutput



        /// <summary>
        /// Deletes the output destination configuration from your SQL-based Amazon Kinesis Data
        /// Analytics application's configuration. Kinesis Data Analytics will no longer write
        /// data from the corresponding in-application stream to the external output destination.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationOutput service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationOutput service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationOutput">REST API Reference for DeleteApplicationOutput Operation</seealso>
        Task<DeleteApplicationOutputResponse> DeleteApplicationOutputAsync(DeleteApplicationOutputRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationReferenceDataSource



        /// <summary>
        /// Deletes a reference data source configuration from the specified SQL-based Amazon
        /// Kinesis Data Analytics application's configuration.
        /// 
        ///  
        /// <para>
        /// If the application is running, Kinesis Data Analytics immediately removes the in-application
        /// table that you created using the <a>AddApplicationReferenceDataSource</a> operation.
        /// 
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationReferenceDataSource service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationReferenceDataSource service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationReferenceDataSource">REST API Reference for DeleteApplicationReferenceDataSource Operation</seealso>
        Task<DeleteApplicationReferenceDataSourceResponse> DeleteApplicationReferenceDataSourceAsync(DeleteApplicationReferenceDataSourceRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationSnapshot



        /// <summary>
        /// Deletes a snapshot of application state.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationSnapshot service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationSnapshot service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.UnsupportedOperationException">
        /// The request was rejected because a specified parameter is not supported or a specified
        /// resource is not valid for this operation.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationSnapshot">REST API Reference for DeleteApplicationSnapshot Operation</seealso>
        Task<DeleteApplicationSnapshotResponse> DeleteApplicationSnapshotAsync(DeleteApplicationSnapshotRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DeleteApplicationVpcConfiguration



        /// <summary>
        /// Removes a VPC configuration from a Kinesis Data Analytics application.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteApplicationVpcConfiguration service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DeleteApplicationVpcConfiguration service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DeleteApplicationVpcConfiguration">REST API Reference for DeleteApplicationVpcConfiguration Operation</seealso>
        Task<DeleteApplicationVpcConfigurationResponse> DeleteApplicationVpcConfigurationAsync(DeleteApplicationVpcConfigurationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DescribeApplication



        /// <summary>
        /// Returns information about a specific Amazon Kinesis Data Analytics application.
        /// 
        ///  
        /// <para>
        /// If you want to retrieve a list of all applications in your account, use the <a>ListApplications</a>
        /// operation.
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DescribeApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DescribeApplication">REST API Reference for DescribeApplication Operation</seealso>
        Task<DescribeApplicationResponse> DescribeApplicationAsync(DescribeApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DescribeApplicationSnapshot



        /// <summary>
        /// Returns information about a snapshot of application state data.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeApplicationSnapshot service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DescribeApplicationSnapshot service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.UnsupportedOperationException">
        /// The request was rejected because a specified parameter is not supported or a specified
        /// resource is not valid for this operation.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DescribeApplicationSnapshot">REST API Reference for DescribeApplicationSnapshot Operation</seealso>
        Task<DescribeApplicationSnapshotResponse> DescribeApplicationSnapshotAsync(DescribeApplicationSnapshotRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  DiscoverInputSchema



        /// <summary>
        /// Infers a schema for an SQL-based Amazon Kinesis Data Analytics application by evaluating
        /// sample records on the specified streaming source (Kinesis data stream or Kinesis Data
        /// Firehose delivery stream) or Amazon S3 object. In the response, the operation returns
        /// the inferred schema and also the sample records that the operation used to infer the
        /// schema.
        /// 
        ///  
        /// <para>
        ///  You can use the inferred schema when configuring a streaming source for your application.
        /// When you create an application using the Kinesis Data Analytics console, the console
        /// uses this operation to infer a schema and show it in the console user interface. 
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DiscoverInputSchema service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the DiscoverInputSchema service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceProvisionedThroughputExceededException">
        /// Discovery failed to get a record from the streaming source because of the Amazon Kinesis
        /// Streams <code>ProvisionedThroughputExceededException</code>. For more information,
        /// see <a href="http://docs.aws.amazon.com/kinesis/latest/APIReference/API_GetRecords.html">GetRecords</a>
        /// in the Amazon Kinesis Streams API Reference.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ServiceUnavailableException">
        /// The service cannot complete the request.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.UnableToDetectSchemaException">
        /// The data format is not valid. Amazon Kinesis Data Analytics cannot detect the schema
        /// for the given streaming source.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/DiscoverInputSchema">REST API Reference for DiscoverInputSchema Operation</seealso>
        Task<DiscoverInputSchemaResponse> DiscoverInputSchemaAsync(DiscoverInputSchemaRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  ListApplications



        /// <summary>
        /// Returns a list of Amazon Kinesis Data Analytics applications in your account. For
        /// each application, the response includes the application name, Amazon Resource Name
        /// (ARN), and status. 
        /// 
        ///  
        /// <para>
        /// If you want detailed information about a specific application, use <a>DescribeApplication</a>.
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListApplications service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the ListApplications service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/ListApplications">REST API Reference for ListApplications Operation</seealso>
        Task<ListApplicationsResponse> ListApplicationsAsync(ListApplicationsRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  ListApplicationSnapshots



        /// <summary>
        /// Lists information about the current application snapshots.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListApplicationSnapshots service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the ListApplicationSnapshots service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.UnsupportedOperationException">
        /// The request was rejected because a specified parameter is not supported or a specified
        /// resource is not valid for this operation.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/ListApplicationSnapshots">REST API Reference for ListApplicationSnapshots Operation</seealso>
        Task<ListApplicationSnapshotsResponse> ListApplicationSnapshotsAsync(ListApplicationSnapshotsRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  ListTagsForResource



        /// <summary>
        /// Retrieves the list of key-value tags assigned to the application. For more information,
        /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListTagsForResource service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the ListTagsForResource service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/ListTagsForResource">REST API Reference for ListTagsForResource Operation</seealso>
        Task<ListTagsForResourceResponse> ListTagsForResourceAsync(ListTagsForResourceRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  StartApplication



        /// <summary>
        /// Starts the specified Amazon Kinesis Data Analytics application. After creating an
        /// application, you must exclusively call this operation to start your application.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the StartApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the StartApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/StartApplication">REST API Reference for StartApplication Operation</seealso>
        Task<StartApplicationResponse> StartApplicationAsync(StartApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  StopApplication



        /// <summary>
        /// Stops the application from processing data. You can stop an application only if it
        /// is in the running state. You can use the <a>DescribeApplication</a> operation to find
        /// the application state.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the StopApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the StopApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/StopApplication">REST API Reference for StopApplication Operation</seealso>
        Task<StopApplicationResponse> StopApplicationAsync(StopApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  TagResource



        /// <summary>
        /// Adds one or more key-value tags to a Kinesis Analytics application. Note that the
        /// maximum number of application tags includes system tags. The maximum number of user-defined
        /// application tags is 50. For more information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the TagResource service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the TagResource service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.TooManyTagsException">
        /// Application created with too many tags, or too many tags added to an application.
        /// Note that the maximum number of application tags includes system tags. The maximum
        /// number of user-defined application tags is 50.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/TagResource">REST API Reference for TagResource Operation</seealso>
        Task<TagResourceResponse> TagResourceAsync(TagResourceRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  UntagResource



        /// <summary>
        /// Removes one or more tags from a Kinesis Analytics application. For more information,
        /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the UntagResource service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the UntagResource service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.TooManyTagsException">
        /// Application created with too many tags, or too many tags added to an application.
        /// Note that the maximum number of application tags includes system tags. The maximum
        /// number of user-defined application tags is 50.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/UntagResource">REST API Reference for UntagResource Operation</seealso>
        Task<UntagResourceResponse> UntagResourceAsync(UntagResourceRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
                
        #region  UpdateApplication



        /// <summary>
        /// Updates an existing Amazon Kinesis Data Analytics application. Using this operation,
        /// you can update application code, input configuration, and output configuration. 
        /// 
        ///  
        /// <para>
        /// Kinesis Data Analytics updates the <code>ApplicationVersionId</code> each time you
        /// update your application. 
        /// </para>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the UpdateApplication service method.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// 
        /// <returns>The response from the UpdateApplication service method, as returned by KinesisAnalyticsV2.</returns>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.CodeValidationException">
        /// The user-provided application code (query) is not valid. This can be a simple syntax
        /// error.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ConcurrentModificationException">
        /// Exception thrown as a result of concurrent modifications to an application. This error
        /// can be the result of attempting to modify an application without using the current
        /// application ID.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidApplicationConfigurationException">
        /// The user-provided application configuration is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidArgumentException">
        /// The specified input parameter value is not valid.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.InvalidRequestException">
        /// The request JSON is not valid for the operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceInUseException">
        /// The application is not available for this operation.
        /// </exception>
        /// <exception cref="Amazon.KinesisAnalyticsV2.Model.ResourceNotFoundException">
        /// Specified application can't be found.
        /// </exception>
        /// <seealso href="http://docs.aws.amazon.com/goto/WebAPI/kinesisanalyticsv2-2018-05-23/UpdateApplication">REST API Reference for UpdateApplication Operation</seealso>
        Task<UpdateApplicationResponse> UpdateApplicationAsync(UpdateApplicationRequest request, System.Threading.CancellationToken cancellationToken = default(CancellationToken));

        #endregion
        
    }
}