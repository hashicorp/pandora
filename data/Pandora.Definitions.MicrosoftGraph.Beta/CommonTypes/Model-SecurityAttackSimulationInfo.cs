// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityAttackSimulationInfoModel
{
    [JsonPropertyName("attackSimDateTime")]
    public DateTime? AttackSimDateTime { get; set; }

    [JsonPropertyName("attackSimDurationTime")]
    public string? AttackSimDurationTime { get; set; }

    [JsonPropertyName("attackSimId")]
    public string? AttackSimId { get; set; }

    [JsonPropertyName("attackSimUserId")]
    public string? AttackSimUserId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
