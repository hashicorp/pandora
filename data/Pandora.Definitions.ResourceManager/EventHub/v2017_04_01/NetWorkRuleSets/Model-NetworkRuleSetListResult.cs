using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetWorkRuleSets
{
	internal class NetworkRuleSetListResult
	{
		[JsonPropertyName("nextLink")]
		public string? NextLink { get; set; }

		[JsonPropertyName("value")]
		public List<NetworkRuleSet>? Value { get; set; }
	}
}
