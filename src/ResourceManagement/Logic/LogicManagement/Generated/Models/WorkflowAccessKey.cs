// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
// Changes may cause incorrect behavior and will be lost if the code is

namespace Microsoft.Azure.Management.Logic.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class WorkflowAccessKey : SubResource
    {
        /// <summary>
        /// Gets the workflow access key name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the workflow access key type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets the not-before time.
        /// </summary>
        [JsonProperty(PropertyName = "properties.notBefore")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Gets or sets the not-after time.
        /// </summary>
        [JsonProperty(PropertyName = "properties.notAfter")]
        public DateTime? NotAfter { get; set; }

    }
}