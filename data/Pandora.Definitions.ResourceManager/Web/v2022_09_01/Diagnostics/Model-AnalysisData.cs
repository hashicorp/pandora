using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;


internal class AnalysisDataModel
{
    [JsonPropertyName("data")]
    public List<List<NameValuePairModel>>? Data { get; set; }

    [JsonPropertyName("detectorDefinition")]
    public DetectorDefinitionModel? DetectorDefinition { get; set; }

    [JsonPropertyName("detectorMetaData")]
    public ResponseMetaDataModel? DetectorMetaData { get; set; }

    [JsonPropertyName("metrics")]
    public List<DiagnosticMetricSetModel>? Metrics { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}
