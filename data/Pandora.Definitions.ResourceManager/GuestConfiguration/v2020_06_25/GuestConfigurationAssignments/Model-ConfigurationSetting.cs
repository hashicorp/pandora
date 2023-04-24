using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationAssignments;


internal class ConfigurationSettingModel
{
    [JsonPropertyName("actionAfterReboot")]
    public ActionAfterRebootConstant? ActionAfterReboot { get; set; }

    [JsonPropertyName("allowModuleOverwrite")]
    public bool? AllowModuleOverwrite { get; set; }

    [JsonPropertyName("configurationMode")]
    public ConfigurationModeConstant? ConfigurationMode { get; set; }

    [JsonPropertyName("configurationModeFrequencyMins")]
    public float? ConfigurationModeFrequencyMins { get; set; }

    [JsonPropertyName("rebootIfNeeded")]
    public bool? RebootIfNeeded { get; set; }

    [JsonPropertyName("refreshFrequencyMins")]
    public float? RefreshFrequencyMins { get; set; }
}
