using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.TagRules;


internal class TagRuleUpdateModel
{
    [JsonPropertyName("logRules")]
    public LogRulesModel? LogRules { get; set; }

    [JsonPropertyName("metricRules")]
    public MetricRulesModel? MetricRules { get; set; }
}
