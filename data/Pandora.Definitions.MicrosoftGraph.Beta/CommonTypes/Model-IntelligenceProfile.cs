// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IntelligenceProfileModel
{
    [JsonPropertyName("aliases")]
    public List<string>? Aliases { get; set; }

    [JsonPropertyName("description")]
    public FormattedContentModel? Description { get; set; }

    [JsonPropertyName("firstActiveDateTime")]
    public DateTime? FirstActiveDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indicators")]
    public List<IntelligenceProfileIndicatorModel>? Indicators { get; set; }

    [JsonPropertyName("kind")]
    public IntelligenceProfileKindConstant? Kind { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sponsorStates")]
    public List<IntelligenceProfileSponsorStateModel>? SponsorStates { get; set; }

    [JsonPropertyName("summary")]
    public FormattedContentModel? Summary { get; set; }

    [JsonPropertyName("targets")]
    public List<string>? Targets { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("tradecraft")]
    public FormattedContentModel? Tradecraft { get; set; }
}
