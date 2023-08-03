// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SynchronizationProgressModel
{
    [JsonPropertyName("completedUnits")]
    public long? CompletedUnits { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("progressObservationDateTime")]
    public DateTime? ProgressObservationDateTime { get; set; }

    [JsonPropertyName("totalUnits")]
    public long? TotalUnits { get; set; }

    [JsonPropertyName("units")]
    public string? Units { get; set; }
}
