using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.CheckNameAvailabilityDisasterRecoveryConfigs
{

	internal class CheckNameAvailabilityResult
	{
		[JsonPropertyName("message")]
		public string? Message { get; set; }

		[JsonPropertyName("nameAvailable")]
		public bool? NameAvailable { get; set; }

		[JsonPropertyName("reason")]
		public UnavailableReason? Reason { get; set; }
	}
}
