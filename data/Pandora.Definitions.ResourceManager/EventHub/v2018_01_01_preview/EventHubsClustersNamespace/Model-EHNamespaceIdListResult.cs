using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace
{

	internal class EHNamespaceIdListResult
	{
		[JsonPropertyName("value")]
		public List<EHNamespaceIdContainer>? Value { get; set; }
	}
}
