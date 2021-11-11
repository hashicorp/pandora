using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType
{

    internal class VaultCertificateModel
    {
        [JsonPropertyName("certificateStore")]
        [Required]
        public string CertificateStore { get; set; }

        [JsonPropertyName("certificateUrl")]
        [Required]
        public string CertificateUrl { get; set; }
    }
}
