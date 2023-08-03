// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AssignmentFilterStatusDetailsModel
{
    [JsonPropertyName("deviceProperties")]
    public List<KeyValuePairModel>? DeviceProperties { get; set; }

    [JsonPropertyName("evalutionSummaries")]
    public List<AssignmentFilterEvaluationSummaryModel>? EvalutionSummaries { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payloadId")]
    public string? PayloadId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
