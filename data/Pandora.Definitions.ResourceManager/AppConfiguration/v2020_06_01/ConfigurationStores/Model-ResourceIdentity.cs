using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class ResourceIdentity
	{
		[JsonPropertyName("principalId")]
		public string? PrincipalId { get; set; }

		[JsonPropertyName("tenantId")]
		public string? TenantId { get; set; }

		[JsonPropertyName("type")]
		public IdentityType Type { get; set; }
		
		// temporarily commented out since this needs supporting
		// [JsonPropertyName("userAssignedIdentities")]
		// public Dictionary<string, UserIdentity>? UserAssignedIdentities { get; set; }
	}
}
