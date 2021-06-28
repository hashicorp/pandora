using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{

	internal class PrivateEndpoint
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }
	}
}
