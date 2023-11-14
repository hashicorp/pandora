using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;


internal class DiagnosticDetectorResponsePropertiesModel
{
    [JsonPropertyName("abnormalTimePeriods")]
    public List<DetectorAbnormalTimePeriodModel>? AbnormalTimePeriods { get; set; }

    [JsonPropertyName("data")]
    public List<List<NameValuePairModel>>? Data { get; set; }

    [JsonPropertyName("detectorDefinition")]
    public DetectorDefinitionModel? DetectorDefinition { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("issueDetected")]
    public bool? IssueDetected { get; set; }

    [JsonPropertyName("metrics")]
    public List<DiagnosticMetricSetModel>? Metrics { get; set; }

    [JsonPropertyName("responseMetaData")]
    public ResponseMetaDataModel? ResponseMetaData { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
