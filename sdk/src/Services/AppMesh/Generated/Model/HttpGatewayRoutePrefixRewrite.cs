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
 * Do not modify this file. This file is generated from the appmesh-2019-01-25.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.AppMesh.Model
{
    /// <summary>
    /// An object representing the beginning characters of the route to rewrite.
    /// </summary>
    public partial class HttpGatewayRoutePrefixRewrite
    {
        private DefaultGatewayRouteRewrite _defaultPrefix;
        private string _value;

        /// <summary>
        /// Gets and sets the property DefaultPrefix. 
        /// <para>
        /// The default prefix used to replace the incoming route prefix when rewritten.
        /// </para>
        /// </summary>
        public DefaultGatewayRouteRewrite DefaultPrefix
        {
            get { return this._defaultPrefix; }
            set { this._defaultPrefix = value; }
        }

        // Check to see if DefaultPrefix property is set
        internal bool IsSetDefaultPrefix()
        {
            return this._defaultPrefix != null;
        }

        /// <summary>
        /// Gets and sets the property Value. 
        /// <para>
        /// The value used to replace the incoming route prefix when rewritten.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=255)]
        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        // Check to see if Value property is set
        internal bool IsSetValue()
        {
            return this._value != null;
        }

    }
}