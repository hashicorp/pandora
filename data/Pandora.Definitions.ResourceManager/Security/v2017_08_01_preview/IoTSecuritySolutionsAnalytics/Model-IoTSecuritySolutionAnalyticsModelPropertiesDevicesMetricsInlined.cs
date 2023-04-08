using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IoTSecuritySolutionsAnalytics;


internal class IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsInlinedModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("devicesMetrics")]
    public IoTSeverityMetricsModel? DevicesMetrics { get; set; }
}
