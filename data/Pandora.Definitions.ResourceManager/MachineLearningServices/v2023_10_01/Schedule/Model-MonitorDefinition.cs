using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;


internal class MonitorDefinitionModel
{
    [JsonPropertyName("alertNotificationSettings")]
    public MonitorNotificationSettingsModel? AlertNotificationSettings { get; set; }

    [JsonPropertyName("computeConfiguration")]
    [Required]
    public MonitorComputeConfigurationBaseModel ComputeConfiguration { get; set; }

    [JsonPropertyName("monitoringTarget")]
    public MonitoringTargetModel? MonitoringTarget { get; set; }

    [JsonPropertyName("signals")]
    [Required]
    public Dictionary<string, MonitoringSignalBaseModel> Signals { get; set; }
}
