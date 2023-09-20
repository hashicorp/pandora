// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageMultipleChoiceQuestionModel
{
    [JsonPropertyName("choices")]
    public List<AccessPackageAnswerChoiceModel>? Choices { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAnswerEditable")]
    public bool? IsAnswerEditable { get; set; }

    [JsonPropertyName("isMultipleSelectionAllowed")]
    public bool? IsMultipleSelectionAllowed { get; set; }

    [JsonPropertyName("isRequired")]
    public bool? IsRequired { get; set; }

    [JsonPropertyName("localizations")]
    public List<AccessPackageLocalizedTextModel>? Localizations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sequence")]
    public int? Sequence { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
