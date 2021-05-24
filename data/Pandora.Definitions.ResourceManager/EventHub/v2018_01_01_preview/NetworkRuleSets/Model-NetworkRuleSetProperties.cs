using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{

	internal class NetworkRuleSetProperties
	{
		[JsonPropertyName("defaultAction")]
		public DefaultAction DefaultAction { get; set; }

		[JsonPropertyName("ipRules")]
		public List<NWRuleSetIpRules>? IpRules { get; set; }

		[JsonPropertyName("trustedServiceAccessEnabled")]
		public bool TrustedServiceAccessEnabled { get; set; }

		[JsonPropertyName("virtualNetworkRules")]
		public List<NWRuleSetVirtualNetworkRules>? VirtualNetworkRules { get; set; }
	}
}
