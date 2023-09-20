// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataIndustryDataRunActivityModel
{
    [JsonPropertyName("activity")]
    public IndustryDataIndustryDataActivityModel? Activity { get; set; }

    [JsonPropertyName("blockingError")]
    public PublicErrorModel? BlockingError { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public IndustryDataIndustryDataRunActivityStatusConstant? Status { get; set; }
}
