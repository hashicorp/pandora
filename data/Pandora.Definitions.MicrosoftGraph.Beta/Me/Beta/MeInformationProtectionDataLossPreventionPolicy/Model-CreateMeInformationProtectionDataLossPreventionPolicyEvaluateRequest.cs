// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionDataLossPreventionPolicy;

internal class CreateMeInformationProtectionDataLossPreventionPolicyEvaluateRequestModel
{
    [JsonPropertyName("evaluationInput")]
    public DlpEvaluationInputModel? EvaluationInput { get; set; }

    [JsonPropertyName("notificationInfo")]
    public DlpNotificationModel? NotificationInfo { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
