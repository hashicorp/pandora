using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolutionAnalytics;


internal class IoTSecuritySolutionAnalyticsModelPropertiesModel
{
    [JsonPropertyName("devicesMetrics")]
    public List<IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsInlinedModel>? DevicesMetrics { get; set; }

    [JsonPropertyName("metrics")]
    public IoTSeverityMetricsModel? Metrics { get; set; }

    [JsonPropertyName("mostPrevalentDeviceAlerts")]
    public List<IoTSecurityDeviceAlertModel>? MostPrevalentDeviceAlerts { get; set; }

    [JsonPropertyName("mostPrevalentDeviceRecommendations")]
    public List<IoTSecurityDeviceRecommendationModel>? MostPrevalentDeviceRecommendations { get; set; }

    [JsonPropertyName("topAlertedDevices")]
    public List<IoTSecurityAlertedDeviceModel>? TopAlertedDevices { get; set; }

    [JsonPropertyName("unhealthyDeviceCount")]
    public int? UnhealthyDeviceCount { get; set; }
}
