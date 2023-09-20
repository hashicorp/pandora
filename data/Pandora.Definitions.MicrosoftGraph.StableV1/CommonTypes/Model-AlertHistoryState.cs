// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AlertHistoryStateModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("assignedTo")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("comments")]
    public List<string>? Comments { get; set; }

    [JsonPropertyName("feedback")]
    public AlertHistoryStateFeedbackConstant? Feedback { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public AlertHistoryStateStatusConstant? Status { get; set; }

    [JsonPropertyName("updatedDateTime")]
    public DateTime? UpdatedDateTime { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}
