// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BookingQuestionAnswerModel
{
    [JsonPropertyName("answer")]
    public string? Answer { get; set; }

    [JsonPropertyName("answerInputType")]
    public BookingQuestionAnswerAnswerInputTypeConstant? AnswerInputType { get; set; }

    [JsonPropertyName("answerOptions")]
    public List<string>? AnswerOptions { get; set; }

    [JsonPropertyName("isRequired")]
    public bool? IsRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("question")]
    public string? Question { get; set; }

    [JsonPropertyName("questionId")]
    public string? QuestionId { get; set; }

    [JsonPropertyName("selectedOptions")]
    public List<string>? SelectedOptions { get; set; }
}
