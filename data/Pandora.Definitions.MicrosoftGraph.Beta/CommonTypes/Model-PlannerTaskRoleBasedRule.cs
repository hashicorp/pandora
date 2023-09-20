// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerTaskRoleBasedRuleModel
{
    [JsonPropertyName("defaultRule")]
    public string? DefaultRule { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("propertyRule")]
    public PlannerTaskPropertyRuleModel? PropertyRule { get; set; }

    [JsonPropertyName("role")]
    public PlannerTaskConfigurationRoleBaseModel? Role { get; set; }
}
