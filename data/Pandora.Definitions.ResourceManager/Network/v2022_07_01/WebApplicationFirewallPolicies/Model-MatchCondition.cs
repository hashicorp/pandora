using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class MatchConditionModel
{
    [JsonPropertyName("matchValues")]
    [Required]
    public List<string> MatchValues { get; set; }

    [JsonPropertyName("matchVariables")]
    [Required]
    public List<MatchVariableModel> MatchVariables { get; set; }

    [JsonPropertyName("negationConditon")]
    public bool? NegationConditon { get; set; }

    [JsonPropertyName("operator")]
    [Required]
    public WebApplicationFirewallOperatorConstant Operator { get; set; }

    [JsonPropertyName("transforms")]
    public List<WebApplicationFirewallTransformConstant>? Transforms { get; set; }
}
