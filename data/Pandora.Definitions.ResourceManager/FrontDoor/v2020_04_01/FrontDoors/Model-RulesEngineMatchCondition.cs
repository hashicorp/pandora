using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class RulesEngineMatchConditionModel
{
    [JsonPropertyName("negateCondition")]
    public bool? NegateCondition { get; set; }

    [JsonPropertyName("rulesEngineMatchValue")]
    [Required]
    public List<string> RulesEngineMatchValue { get; set; }

    [JsonPropertyName("rulesEngineMatchVariable")]
    [Required]
    public RulesEngineMatchVariableConstant RulesEngineMatchVariable { get; set; }

    [JsonPropertyName("rulesEngineOperator")]
    [Required]
    public RulesEngineOperatorConstant RulesEngineOperator { get; set; }

    [JsonPropertyName("selector")]
    public string? Selector { get; set; }

    [JsonPropertyName("transforms")]
    public List<TransformConstant>? Transforms { get; set; }
}
