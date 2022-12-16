using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Outputs;


internal class OutputPropertiesModel
{
    [JsonPropertyName("datasource")]
    public OutputDataSourceModel? Datasource { get; set; }

    [JsonPropertyName("diagnostics")]
    public DiagnosticsModel? Diagnostics { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("lastOutputEventTimestamps")]
    public List<LastOutputEventTimestampModel>? LastOutputEventTimestamps { get; set; }

    [JsonPropertyName("serialization")]
    public SerializationModel? Serialization { get; set; }

    [JsonPropertyName("sizeWindow")]
    public int? SizeWindow { get; set; }

    [JsonPropertyName("timeWindow")]
    public string? TimeWindow { get; set; }

    [JsonPropertyName("watermarkSettings")]
    public OutputWatermarkPropertiesModel? WatermarkSettings { get; set; }
}
