// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MessageRuleModel
{
    [JsonPropertyName("actions")]
    public MessageRuleActionsModel? Actions { get; set; }

    [JsonPropertyName("conditions")]
    public MessageRulePredicatesModel? Conditions { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("exceptions")]
    public MessageRulePredicatesModel? Exceptions { get; set; }

    [JsonPropertyName("hasError")]
    public bool? HasError { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("isReadOnly")]
    public bool? IsReadOnly { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sequence")]
    public int? Sequence { get; set; }
}
