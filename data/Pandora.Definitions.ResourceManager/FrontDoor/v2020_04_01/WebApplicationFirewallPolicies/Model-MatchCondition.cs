using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;


internal class MatchConditionModel
{
    [JsonPropertyName("matchValue")]
    [Required]
    public List<string> MatchValue { get; set; }

    [JsonPropertyName("matchVariable")]
    [Required]
    public MatchVariableConstant MatchVariable { get; set; }

    [JsonPropertyName("negateCondition")]
    public bool? NegateCondition { get; set; }

    [JsonPropertyName("operator")]
    [Required]
    public OperatorConstant Operator { get; set; }

    [JsonPropertyName("selector")]
    public string? Selector { get; set; }

    [JsonPropertyName("transforms")]
    public List<TransformTypeConstant>? Transforms { get; set; }
}
