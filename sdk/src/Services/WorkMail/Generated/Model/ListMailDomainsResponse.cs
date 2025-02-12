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
 * Do not modify this file. This file is generated from the workmail-2017-10-01.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.WorkMail.Model
{
    /// <summary>
    /// This is the response object from the ListMailDomains operation.
    /// </summary>
    public partial class ListMailDomainsResponse : AmazonWebServiceResponse
    {
        private List<MailDomainSummary> _mailDomains = new List<MailDomainSummary>();
        private string _nextToken;

        /// <summary>
        /// Gets and sets the property MailDomains. 
        /// <para>
        /// The list of mail domain summaries, specifying domains that exist in the specified
        /// Amazon WorkMail organization, along with the information about whether the domain
        /// is or isn't the default.
        /// </para>
        /// </summary>
        public List<MailDomainSummary> MailDomains
        {
            get { return this._mailDomains; }
            set { this._mailDomains = value; }
        }

        // Check to see if MailDomains property is set
        internal bool IsSetMailDomains()
        {
            return this._mailDomains != null && this._mailDomains.Count > 0; 
        }

        /// <summary>
        /// Gets and sets the property NextToken. 
        /// <para>
        /// The token to use to retrieve the next page of results. The value becomes <code>null</code>
        /// when there are no more results to return.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=1024)]
        public string NextToken
        {
            get { return this._nextToken; }
            set { this._nextToken = value; }
        }

        // Check to see if NextToken property is set
        internal bool IsSetNextToken()
        {
            return this._nextToken != null;
        }

    }
}