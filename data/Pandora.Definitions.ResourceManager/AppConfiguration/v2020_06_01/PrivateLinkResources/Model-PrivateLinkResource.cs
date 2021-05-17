using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
	internal class PrivateLinkResource
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("properties")]
		public PrivateLinkResourceProperties? Properties { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}
