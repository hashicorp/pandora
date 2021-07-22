using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class ConfigurationStoreProperties
    {
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("encryption")]
        public EncryptionProperties? Encryption { get; set; }

        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        [JsonPropertyName("privateEndpointConnections")]
        public List<PrivateEndpointConnection>? PrivateEndpointConnections { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningState ProvisioningState { get; set; }

        [JsonPropertyName("publicNetworkAccess")]
        public PublicNetworkAccess PublicNetworkAccess { get; set; }
    }
}
