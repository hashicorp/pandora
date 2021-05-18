using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class PrivateLinkServiceConnectionState
	{
		[JsonPropertyName("actionsRequired")]
		public ActionsRequired ActionsRequired { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("status")]
		public ConnectionStatus Status { get; set; }
	}
}
