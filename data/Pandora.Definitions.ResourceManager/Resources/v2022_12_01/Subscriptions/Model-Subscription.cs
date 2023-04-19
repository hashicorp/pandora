using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;


internal class SubscriptionModel
{
    [JsonPropertyName("authorizationSource")]
    public string? AuthorizationSource { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedByTenants")]
    public List<ManagedByTenantModel>? ManagedByTenants { get; set; }

    [JsonPropertyName("state")]
    public SubscriptionStateConstant? State { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("subscriptionPolicies")]
    public SubscriptionPoliciesModel? SubscriptionPolicies { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
