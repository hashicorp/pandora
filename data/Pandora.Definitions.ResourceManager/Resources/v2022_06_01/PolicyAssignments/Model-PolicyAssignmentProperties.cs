using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_06_01.PolicyAssignments;


internal class PolicyAssignmentPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforcementMode")]
    public EnforcementModeConstant? EnforcementMode { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("nonComplianceMessages")]
    public List<NonComplianceMessageModel>? NonComplianceMessages { get; set; }

    [JsonPropertyName("notScopes")]
    public List<string>? NotScopes { get; set; }

    [JsonPropertyName("overrides")]
    public List<OverrideModel>? Overrides { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterValuesValueModel>? Parameters { get; set; }

    [JsonPropertyName("policyDefinitionId")]
    public string? PolicyDefinitionId { get; set; }

    [JsonPropertyName("resourceSelectors")]
    public List<ResourceSelectorModel>? ResourceSelectors { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
