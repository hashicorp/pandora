// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChatMessagePolicyViolationPolicyTipModel
{
    [JsonPropertyName("complianceUrl")]
    public string? ComplianceUrl { get; set; }

    [JsonPropertyName("generalText")]
    public string? GeneralText { get; set; }

    [JsonPropertyName("matchedConditionDescriptions")]
    public List<string>? MatchedConditionDescriptions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
