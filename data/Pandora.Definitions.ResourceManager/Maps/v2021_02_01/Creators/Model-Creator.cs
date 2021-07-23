using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{

	internal class Creator
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("location")]
		[Required]
		public CustomTypes.Location Location { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("properties")]
		[Required]
		public CreatorProperties Properties { get; set; }

		[JsonPropertyName("tags")]
		public CustomTypes.Tags? Tags { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}
