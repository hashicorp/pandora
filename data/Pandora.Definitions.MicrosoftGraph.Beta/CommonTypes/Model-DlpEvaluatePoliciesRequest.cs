// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DlpEvaluatePoliciesRequestModel
{
    [JsonPropertyName("evaluationInput")]
    public DlpEvaluationInputModel? EvaluationInput { get; set; }

    [JsonPropertyName("notificationInfo")]
    public DlpNotificationModel? NotificationInfo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
