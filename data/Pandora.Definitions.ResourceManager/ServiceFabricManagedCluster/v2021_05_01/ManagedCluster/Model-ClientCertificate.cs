using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster
{

    internal class ClientCertificateModel
    {
        [JsonPropertyName("commonName")]
        public string? CommonName { get; set; }

        [JsonPropertyName("isAdmin")]
        [Required]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("issuerThumbprint")]
        public string? IssuerThumbprint { get; set; }

        [JsonPropertyName("thumbprint")]
        public string? Thumbprint { get; set; }
    }
}
