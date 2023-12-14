// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCOnPremisesConnectionModel
{
    [JsonPropertyName("adDomainName")]
    public string? AdDomainName { get; set; }

    [JsonPropertyName("adDomainPassword")]
    public string? AdDomainPassword { get; set; }

    [JsonPropertyName("adDomainUsername")]
    public string? AdDomainUsername { get; set; }

    [JsonPropertyName("alternateResourceUrl")]
    public string? AlternateResourceUrl { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("healthCheckStatus")]
    public CloudPCOnPremisesConnectionHealthCheckStatusConstant? HealthCheckStatus { get; set; }

    [JsonPropertyName("healthCheckStatusDetails")]
    public CloudPCOnPremisesConnectionStatusDetailsModel? HealthCheckStatusDetails { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inUse")]
    public bool? InUse { get; set; }

    [JsonPropertyName("managedBy")]
    public CloudPCOnPremisesConnectionManagedByConstant? ManagedBy { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizationalUnit")]
    public string? OrganizationalUnit { get; set; }

    [JsonPropertyName("resourceGroupId")]
    public string? ResourceGroupId { get; set; }

    [JsonPropertyName("scopeIds")]
    public List<string>? ScopeIds { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("subscriptionName")]
    public string? SubscriptionName { get; set; }

    [JsonPropertyName("type")]
    public CloudPCOnPremisesConnectionTypeConstant? Type { get; set; }

    [JsonPropertyName("virtualNetworkId")]
    public string? VirtualNetworkId { get; set; }

    [JsonPropertyName("virtualNetworkLocation")]
    public string? VirtualNetworkLocation { get; set; }
}
