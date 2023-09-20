// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ChatMessagePolicyViolationModel
{
    [JsonPropertyName("dlpAction")]
    public ChatMessagePolicyViolationDlpActionConstant? DlpAction { get; set; }

    [JsonPropertyName("justificationText")]
    public string? JustificationText { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyTip")]
    public ChatMessagePolicyViolationPolicyTipModel? PolicyTip { get; set; }

    [JsonPropertyName("userAction")]
    public ChatMessagePolicyViolationUserActionConstant? UserAction { get; set; }

    [JsonPropertyName("verdictDetails")]
    public ChatMessagePolicyViolationVerdictDetailsConstant? VerdictDetails { get; set; }
}
