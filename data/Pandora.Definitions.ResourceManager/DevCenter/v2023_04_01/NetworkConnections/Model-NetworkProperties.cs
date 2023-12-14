using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.NetworkConnections;


internal class NetworkPropertiesModel
{
    [JsonPropertyName("domainJoinType")]
    [Required]
    public DomainJoinTypeConstant DomainJoinType { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("domainPassword")]
    public string? DomainPassword { get; set; }

    [JsonPropertyName("domainUsername")]
    public string? DomainUsername { get; set; }

    [JsonPropertyName("healthCheckStatus")]
    public HealthCheckStatusConstant? HealthCheckStatus { get; set; }

    [JsonPropertyName("networkingResourceGroupName")]
    public string? NetworkingResourceGroupName { get; set; }

    [JsonPropertyName("organizationUnit")]
    public string? OrganizationUnit { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("subnetId")]
    [Required]
    public string SubnetId { get; set; }
}
