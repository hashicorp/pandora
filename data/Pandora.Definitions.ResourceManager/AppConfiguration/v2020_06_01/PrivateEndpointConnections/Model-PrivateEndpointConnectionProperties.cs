using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateEndpointConnections
{
	internal class PrivateEndpointConnectionProperties
	{
		[JsonPropertyName("privateEndpoint")]
		public PrivateEndpoint? PrivateEndpoint { get; set; }

		[JsonPropertyName("privateLinkServiceConnectionState")]
		[Required]
		public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

		[JsonPropertyName("provisioningState")]
		public ProvisioningState ProvisioningState { get; set; }
	}
}
