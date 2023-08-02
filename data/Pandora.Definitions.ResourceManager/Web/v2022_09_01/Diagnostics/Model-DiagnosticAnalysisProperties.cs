using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;


internal class DiagnosticAnalysisPropertiesModel
{
    [JsonPropertyName("abnormalTimePeriods")]
    public List<AbnormalTimePeriodModel>? AbnormalTimePeriods { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("nonCorrelatedDetectors")]
    public List<DetectorDefinitionModel>? NonCorrelatedDetectors { get; set; }

    [JsonPropertyName("payload")]
    public List<AnalysisDataModel>? Payload { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
