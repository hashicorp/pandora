using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{

	internal class CreatorProperties
	{
		[JsonPropertyName("provisioningState")]
		public string? ProvisioningState { get; set; }

		[JsonPropertyName("storageUnits")]
		[Required]
		public int StorageUnits { get; set; }
	}
}
