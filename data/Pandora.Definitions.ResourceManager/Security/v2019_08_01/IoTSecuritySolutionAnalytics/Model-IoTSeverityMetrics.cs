using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolutionAnalytics;


internal class IoTSeverityMetricsModel
{
    [JsonPropertyName("high")]
    public int? High { get; set; }

    [JsonPropertyName("low")]
    public int? Low { get; set; }

    [JsonPropertyName("medium")]
    public int? Medium { get; set; }
}
