// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SynchronizationQuarantineModel
{
    [JsonPropertyName("currentBegan")]
    public DateTime? CurrentBegan { get; set; }

    [JsonPropertyName("error")]
    public SynchronizationErrorModel? Error { get; set; }

    [JsonPropertyName("nextAttempt")]
    public DateTime? NextAttempt { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reason")]
    public SynchronizationQuarantineReasonConstant? Reason { get; set; }

    [JsonPropertyName("seriesBegan")]
    public DateTime? SeriesBegan { get; set; }

    [JsonPropertyName("seriesCount")]
    public int? SeriesCount { get; set; }
}
