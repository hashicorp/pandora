using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicySetDefinitionVersions;


internal class PolicySetDefinitionVersionPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterDefinitionsValueModel>? Parameters { get; set; }

    [JsonPropertyName("policyDefinitionGroups")]
    public List<PolicyDefinitionGroupModel>? PolicyDefinitionGroups { get; set; }

    [JsonPropertyName("policyDefinitions")]
    [Required]
    public List<PolicyDefinitionReferenceModel> PolicyDefinitions { get; set; }

    [JsonPropertyName("policyType")]
    public PolicyTypeConstant? PolicyType { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
