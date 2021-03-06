// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;

namespace Microsoft.WindowsAzure.Management.SiteRecovery.Models
{
    /// <summary>
    /// The definition of a create mapping input object.
    /// </summary>
    public partial class NetworkMappingInput
    {
        private string _createNetworkMappingInput;
        
        /// <summary>
        /// Required. Create network mapping input.
        /// </summary>
        public string CreateNetworkMappingInput
        {
            get { return this._createNetworkMappingInput; }
            set { this._createNetworkMappingInput = value; }
        }
        
        private string _networkTargetType;
        
        /// <summary>
        /// Required. Network target type.
        /// </summary>
        public string NetworkTargetType
        {
            get { return this._networkTargetType; }
            set { this._networkTargetType = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the NetworkMappingInput class.
        /// </summary>
        public NetworkMappingInput()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the NetworkMappingInput class with
        /// required arguments.
        /// </summary>
        public NetworkMappingInput(string networkTargetType, string createNetworkMappingInput)
            : this()
        {
            if (networkTargetType == null)
            {
                throw new ArgumentNullException("networkTargetType");
            }
            if (createNetworkMappingInput == null)
            {
                throw new ArgumentNullException("createNetworkMappingInput");
            }
            this.NetworkTargetType = networkTargetType;
            this.CreateNetworkMappingInput = createNetworkMappingInput;
        }
    }
}
