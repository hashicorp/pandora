using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AutomationRules;


internal class AutomationRulePropertyValuesConditionConditionPropertiesModel
{
    [JsonPropertyName("operator")]
    public AutomationRulePropertyConditionSupportedOperatorConstant? Operator { get; set; }

    [JsonPropertyName("propertyName")]
    public AutomationRulePropertyConditionSupportedPropertyConstant? PropertyName { get; set; }

    [JsonPropertyName("propertyValues")]
    public List<string>? PropertyValues { get; set; }
}
