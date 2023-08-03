// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RecordOperationModel
{
    [JsonPropertyName("clientContext")]
    public string? ClientContext { get; set; }

    [JsonPropertyName("completionReason")]
    public RecordCompletionReasonConstant? CompletionReason { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recordingAccessToken")]
    public string? RecordingAccessToken { get; set; }

    [JsonPropertyName("recordingLocation")]
    public string? RecordingLocation { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("status")]
    public OperationStatusConstant? Status { get; set; }
}
