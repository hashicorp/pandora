using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;


internal class AppServiceInfoModel
{
    [JsonPropertyName("autoUpdateSetting")]
    public AutoUpdateSettingConstant? AutoUpdateSetting { get; set; }

    [JsonPropertyName("availabilityState")]
    public AvailabilityStateConstant? AvailabilityState { get; set; }

    [JsonPropertyName("hostGroup")]
    public string? HostGroup { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("logModule")]
    public LogModuleConstant? LogModule { get; set; }

    [JsonPropertyName("monitoringType")]
    public MonitoringTypeConstant? MonitoringType { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("updateStatus")]
    public UpdateStatusConstant? UpdateStatus { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
