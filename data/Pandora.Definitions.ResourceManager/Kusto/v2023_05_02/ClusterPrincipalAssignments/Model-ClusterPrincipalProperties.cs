using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.ClusterPrincipalAssignments;


internal class ClusterPrincipalPropertiesModel
{
    [JsonPropertyName("aadObjectId")]
    public string? AadObjectId { get; set; }

    [JsonPropertyName("principalId")]
    [Required]
    public string PrincipalId { get; set; }

    [JsonPropertyName("principalName")]
    public string? PrincipalName { get; set; }

    [JsonPropertyName("principalType")]
    [Required]
    public PrincipalTypeConstant PrincipalType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("role")]
    [Required]
    public ClusterPrincipalRoleConstant Role { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("tenantName")]
    public string? TenantName { get; set; }
}
