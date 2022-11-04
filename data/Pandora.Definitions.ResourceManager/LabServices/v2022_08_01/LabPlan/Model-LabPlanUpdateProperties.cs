using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.LabPlan;


internal class LabPlanUpdatePropertiesModel
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

    [JsonPropertyName("sharedGalleryId")]
    public string? SharedGalleryId { get; set; }

    [JsonPropertyName("supportInfo")]
    public SupportInfoModel? SupportInfo { get; set; }
}
