using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{

	internal class Identity
	{
		[JsonPropertyName("principalId")]
		public string? PrincipalId { get; set; }

		[JsonPropertyName("tenantId")]
		public string? TenantId { get; set; }

		[JsonPropertyName("type")]
		public ManagedServiceIdentityType? Type { get; set; }

		[JsonPropertyName("userAssignedIdentities")]
		public UserAssignedIdentityProperties? UserAssignedIdentities { get; set; }
	}
}
