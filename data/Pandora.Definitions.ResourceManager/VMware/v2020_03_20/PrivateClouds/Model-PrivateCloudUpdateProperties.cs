using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{

    internal class PrivateCloudUpdateProperties
    {
        [JsonPropertyName("identitySources")]
        public List<IdentitySource>? IdentitySources { get; set; }

        [JsonPropertyName("internet")]
        public InternetEnum? Internet { get; set; }

        [JsonPropertyName("managementCluster")]
        public ManagementCluster? ManagementCluster { get; set; }
    }
}
