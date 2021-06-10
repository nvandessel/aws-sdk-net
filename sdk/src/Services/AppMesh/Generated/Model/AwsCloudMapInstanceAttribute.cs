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
    /// An object that represents the Cloud Map attribute information for your virtual node.
    /// 
    ///  <note> 
    /// <para>
    /// AWS Cloud Map is not available in the eu-south-1 Region.
    /// </para>
    ///  </note>
    /// </summary>
    public partial class AwsCloudMapInstanceAttribute
    {
        private string _key;
        private string _value;

        /// <summary>
        /// Gets and sets the property Key. 
        /// <para>
        /// The name of an Cloud Map service instance attribute key. Any Cloud Map service instance
        /// that contains the specified key and value is returned.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=255)]
        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        // Check to see if Key property is set
        internal bool IsSetKey()
        {
            return this._key != null;
        }

        /// <summary>
        /// Gets and sets the property Value. 
        /// <para>
        /// The value of an Cloud Map service instance attribute key. Any Cloud Map service instance
        /// that contains the specified key and value is returned.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=1024)]
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