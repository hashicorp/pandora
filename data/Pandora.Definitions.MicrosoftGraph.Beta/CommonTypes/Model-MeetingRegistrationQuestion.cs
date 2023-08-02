// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MeetingRegistrationQuestionModel
{
    [JsonPropertyName("answerInputType")]
    public AnswerInputTypeConstant? AnswerInputType { get; set; }

    [JsonPropertyName("answerOptions")]
    public List<string>? AnswerOptions { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isRequired")]
    public bool? IsRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
