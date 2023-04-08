using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolutionAnalytics;


internal class IoTSecurityDeviceAlertModel
{
    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertsCount")]
    public int? AlertsCount { get; set; }

    [JsonPropertyName("reportedSeverity")]
    public ReportedSeverityConstant? ReportedSeverity { get; set; }
}
