using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicySetDefinitions;


internal class PolicyDefinitionReferenceModel
{
    [JsonPropertyName("groupNames")]
    public List<string>? GroupNames { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterValuesValueModel>? Parameters { get; set; }

    [JsonPropertyName("policyDefinitionId")]
    [Required]
    public string PolicyDefinitionId { get; set; }

    [JsonPropertyName("policyDefinitionReferenceId")]
    public string? PolicyDefinitionReferenceId { get; set; }
}
