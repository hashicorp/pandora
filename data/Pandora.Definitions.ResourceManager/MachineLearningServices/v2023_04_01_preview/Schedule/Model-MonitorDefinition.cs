using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;


internal class MonitorDefinitionModel
{
    [JsonPropertyName("alertNotificationSetting")]
    public MonitoringAlertNotificationSettingsBaseModel? AlertNotificationSetting { get; set; }

    [JsonPropertyName("computeId")]
    [Required]
    public string ComputeId { get; set; }

    [JsonPropertyName("monitoringTarget")]
    public string? MonitoringTarget { get; set; }

    [JsonPropertyName("signals")]
    [Required]
    public Dictionary<string, MonitoringSignalBaseModel> Signals { get; set; }
}
