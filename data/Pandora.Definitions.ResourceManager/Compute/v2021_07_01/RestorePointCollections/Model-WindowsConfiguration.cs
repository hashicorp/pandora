using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.RestorePointCollections;


internal class WindowsConfigurationModel
{
    [JsonPropertyName("additionalUnattendContent")]
    public List<AdditionalUnattendContentModel>? AdditionalUnattendContent { get; set; }

    [JsonPropertyName("enableAutomaticUpdates")]
    public bool? EnableAutomaticUpdates { get; set; }

    [JsonPropertyName("patchSettings")]
    public PatchSettingsModel? PatchSettings { get; set; }

    [JsonPropertyName("provisionVMAgent")]
    public bool? ProvisionVMAgent { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("winRM")]
    public WinRMConfigurationModel? WinRM { get; set; }
}
