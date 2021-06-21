using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{

	internal class Encryption
	{
		[JsonPropertyName("keySource")]
		public KeySource? KeySource { get; set; }

		[JsonPropertyName("keyVaultProperties")]
		public List<KeyVaultProperties>? KeyVaultProperties { get; set; }

		[JsonPropertyName("requireInfrastructureEncryption")]
		public bool? RequireInfrastructureEncryption { get; set; }
	}
}
