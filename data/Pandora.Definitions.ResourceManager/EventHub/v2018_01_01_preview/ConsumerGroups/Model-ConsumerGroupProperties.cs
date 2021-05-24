using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.ConsumerGroups
{

	internal class ConsumerGroupProperties
	{
		[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
		[JsonPropertyName("createdAt")]
		public DateTime CreatedAt { get; set; }

		[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
		[JsonPropertyName("updatedAt")]
		public DateTime UpdatedAt { get; set; }

		[JsonPropertyName("userMetadata")]
		public string? UserMetadata { get; set; }
	}
}
