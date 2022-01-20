using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType;


internal class VMSSExtensionPropertiesModel
{
    [JsonPropertyName("autoUpgradeMinorVersion")]
    public bool? AutoUpgradeMinorVersion { get; set; }

    [JsonPropertyName("forceUpdateTag")]
    public string? ForceUpdateTag { get; set; }

    [JsonPropertyName("protectedSettings")]
    public object? ProtectedSettings { get; set; }

    [JsonPropertyName("provisionAfterExtensions")]
    public List<string>? ProvisionAfterExtensions { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publisher")]
    [Required]
    public string Publisher { get; set; }

    [JsonPropertyName("settings")]
    public object? Settings { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public string Type { get; set; }

    [JsonPropertyName("typeHandlerVersion")]
    [Required]
    public string TypeHandlerVersion { get; set; }
}
