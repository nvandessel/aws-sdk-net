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
 * Do not modify this file. This file is generated from the proton-2020-07-20.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.Proton.Model
{
    /// <summary>
    /// The repository sync definition.
    /// </summary>
    public partial class RepositorySyncDefinition
    {
        private string _branch;
        private string _directory;
        private string _parent;
        private string _target;

        /// <summary>
        /// Gets and sets the property Branch. 
        /// <para>
        /// The repository branch.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=200)]
        public string Branch
        {
            get { return this._branch; }
            set { this._branch = value; }
        }

        // Check to see if Branch property is set
        internal bool IsSetBranch()
        {
            return this._branch != null;
        }

        /// <summary>
        /// Gets and sets the property Directory. 
        /// <para>
        /// The directory in the repository.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public string Directory
        {
            get { return this._directory; }
            set { this._directory = value; }
        }

        // Check to see if Directory property is set
        internal bool IsSetDirectory()
        {
            return this._directory != null;
        }

        /// <summary>
        /// Gets and sets the property Parent. 
        /// <para>
        /// The resource that is synced from.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public string Parent
        {
            get { return this._parent; }
            set { this._parent = value; }
        }

        // Check to see if Parent property is set
        internal bool IsSetParent()
        {
            return this._parent != null;
        }

        /// <summary>
        /// Gets and sets the property Target. 
        /// <para>
        /// The resource that is synced to.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public string Target
        {
            get { return this._target; }
            set { this._target = value; }
        }

        // Check to see if Target property is set
        internal bool IsSetTarget()
        {
            return this._target != null;
        }

    }
}