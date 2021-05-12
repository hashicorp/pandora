using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.DataPlane.Synapse.v2020_08_01_preview.SynapseRoleDefinitions
{
	internal class SynapseRoleDefinition
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("isBuiltIn")]
		public bool? IsBuiltIn { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("permissions")]
		public List<string>? Permissions { get; set; }

		[JsonPropertyName("scopes")]
		public List<string>? Scopes { get; set; }

		[JsonPropertyName("availabilityStatus")]
		public string? AvailabilityStatus { get; set; }
	}
}
