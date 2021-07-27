using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{

    internal class PrivateCloudProperties
    {
        [JsonPropertyName("circuit")]
        public Circuit? Circuit { get; set; }

        [JsonPropertyName("endpoints")]
        public Endpoints? Endpoints { get; set; }

        [JsonPropertyName("identitySources")]
        public List<IdentitySource>? IdentitySources { get; set; }

        [JsonPropertyName("internet")]
        public InternetEnum? Internet { get; set; }

        [JsonPropertyName("managementCluster")]
        [Required]
        public ManagementCluster ManagementCluster { get; set; }

        [JsonPropertyName("managementNetwork")]
        public string? ManagementNetwork { get; set; }

        [JsonPropertyName("networkBlock")]
        [Required]
        public string NetworkBlock { get; set; }

        [JsonPropertyName("nsxtCertificateThumbprint")]
        public string? NsxtCertificateThumbprint { get; set; }

        [JsonPropertyName("nsxtPassword")]
        public string? NsxtPassword { get; set; }

        [JsonPropertyName("provisioningNetwork")]
        public string? ProvisioningNetwork { get; set; }

        [JsonPropertyName("provisioningState")]
        public PrivateCloudProvisioningState? ProvisioningState { get; set; }

        [JsonPropertyName("vcenterCertificateThumbprint")]
        public string? VcenterCertificateThumbprint { get; set; }

        [JsonPropertyName("vcenterPassword")]
        public string? VcenterPassword { get; set; }

        [JsonPropertyName("vmotionNetwork")]
        public string? VmotionNetwork { get; set; }
    }
}
