// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEventRegistrationQuestionAnswerModel
{
    [JsonPropertyName("booleanValue")]
    public bool? BooleanValue { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("multiChoiceValues")]
    public List<string>? MultiChoiceValues { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("questionId")]
    public string? QuestionId { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
