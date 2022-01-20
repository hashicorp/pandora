using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.LabPlan;


internal class LabPlanPropertiesModel
{
    [JsonPropertyName("allowedRegions")]
    public List<string>? AllowedRegions { get; set; }

    [JsonPropertyName("defaultAutoShutdownProfile")]
    public AutoShutdownProfileModel? DefaultAutoShutdownProfile { get; set; }

    [JsonPropertyName("defaultConnectionProfile")]
    public ConnectionProfileModel? DefaultConnectionProfile { get; set; }

    [JsonPropertyName("defaultNetworkProfile")]
    public LabPlanNetworkProfileModel? DefaultNetworkProfile { get; set; }

    [JsonPropertyName("linkedLmsInstance")]
    public string? LinkedLmsInstance { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sharedGalleryId")]
    public string? SharedGalleryId { get; set; }

    [JsonPropertyName("supportInfo")]
    public SupportInfoModel? SupportInfo { get; set; }
}
