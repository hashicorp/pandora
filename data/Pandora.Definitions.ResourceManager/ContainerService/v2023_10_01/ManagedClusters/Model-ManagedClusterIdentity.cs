using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.ManagedClusters;


internal class ManagedClusterIdentityModel
{
    [JsonPropertyName("delegatedResources")]
    public Dictionary<string, DelegatedResourceModel>? DelegatedResources { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("type")]
    public ResourceIdentityTypeConstant? Type { get; set; }

    [JsonPropertyName("userAssignedIdentities")]
    public Dictionary<string, UserAssignedIdentitiesPropertiesModel>? UserAssignedIdentities { get; set; }
}
