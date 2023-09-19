// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsWorkloadActionDeploymentStatusModel
{
    [JsonPropertyName("actionId")]
    public string? ActionId { get; set; }

    [JsonPropertyName("deployedPolicyId")]
    public string? DeployedPolicyId { get; set; }

    [JsonPropertyName("error")]
    public GenericErrorModel? Error { get; set; }

    [JsonPropertyName("excludeGroups")]
    public List<string>? ExcludeGroups { get; set; }

    [JsonPropertyName("includeAllUsers")]
    public bool? IncludeAllUsers { get; set; }

    [JsonPropertyName("includeGroups")]
    public List<string>? IncludeGroups { get; set; }

    [JsonPropertyName("lastDeploymentDateTime")]
    public DateTime? LastDeploymentDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public ManagedTenantsWorkloadActionDeploymentStatusStatusConstant? Status { get; set; }
}
