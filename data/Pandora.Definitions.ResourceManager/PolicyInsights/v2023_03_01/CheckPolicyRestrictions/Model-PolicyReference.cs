using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;


internal class PolicyReferenceModel
{
    [JsonPropertyName("policyAssignmentId")]
    public string? PolicyAssignmentId { get; set; }

    [JsonPropertyName("policyDefinitionId")]
    public string? PolicyDefinitionId { get; set; }

    [JsonPropertyName("policyDefinitionReferenceId")]
    public string? PolicyDefinitionReferenceId { get; set; }

    [JsonPropertyName("policySetDefinitionId")]
    public string? PolicySetDefinitionId { get; set; }
}
