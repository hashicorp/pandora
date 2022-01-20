using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities;


internal class DedicatedCapacityMutablePropertiesModel
{
    [JsonPropertyName("administration")]
    public DedicatedCapacityAdministratorsModel? Administration { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("mode")]
    public ModeConstant? Mode { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
