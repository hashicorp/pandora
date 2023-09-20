// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityHostReputationModel
{
    [JsonPropertyName("classification")]
    public SecurityHostReputationClassificationConstant? Classification { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rules")]
    public List<SecurityHostReputationRuleModel>? Rules { get; set; }

    [JsonPropertyName("score")]
    public int? Score { get; set; }
}
