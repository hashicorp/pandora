using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentFeaturesAndPricingAPIs;


internal class ApplicationInsightsComponentDataVolumeCapModel
{
    [JsonPropertyName("Cap")]
    public float? Cap { get; set; }

    [JsonPropertyName("MaxHistoryCap")]
    public float? MaxHistoryCap { get; set; }

    [JsonPropertyName("ResetTime")]
    public int? ResetTime { get; set; }

    [JsonPropertyName("StopSendNotificationWhenHitCap")]
    public bool? StopSendNotificationWhenHitCap { get; set; }

    [JsonPropertyName("StopSendNotificationWhenHitThreshold")]
    public bool? StopSendNotificationWhenHitThreshold { get; set; }

    [JsonPropertyName("WarningThreshold")]
    public int? WarningThreshold { get; set; }
}
