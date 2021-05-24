using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
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
