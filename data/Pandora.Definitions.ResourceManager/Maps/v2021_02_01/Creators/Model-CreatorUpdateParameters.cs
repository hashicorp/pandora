using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{

	internal class CreatorUpdateParameters
	{
		[JsonPropertyName("properties")]
		public CreatorProperties? Properties { get; set; }

		[JsonPropertyName("tags")]
		public CustomTypes.Tags? Tags { get; set; }
	}
}
