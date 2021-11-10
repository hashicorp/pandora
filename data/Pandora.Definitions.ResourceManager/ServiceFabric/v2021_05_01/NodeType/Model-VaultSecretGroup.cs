using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.NodeType
{

    internal class VaultSecretGroupModel
    {
        [JsonPropertyName("sourceVault")]
        [Required]
        public SubResourceModel SourceVault { get; set; }

        [JsonPropertyName("vaultCertificates")]
        [Required]
        public List<VaultCertificateModel> VaultCertificates { get; set; }
    }
}
