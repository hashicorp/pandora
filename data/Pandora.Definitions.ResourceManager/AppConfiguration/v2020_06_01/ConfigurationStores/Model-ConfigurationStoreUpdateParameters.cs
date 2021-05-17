using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class ConfigurationStoreUpdateParameters
	{
		[JsonPropertyName("identity")]
		public ResourceIdentity? Identity { get; set; }

		[JsonPropertyName("properties")]
		public ConfigurationStorePropertiesUpdateParameters? Properties { get; set; }

		[JsonPropertyName("sku")]
		public Sku? Sku { get; set; }

		[JsonPropertyName("tags")]
		public Tags Tags { get; set; }
	}
}
