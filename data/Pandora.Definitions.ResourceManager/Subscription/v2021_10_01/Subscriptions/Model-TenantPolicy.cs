using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;


internal class TenantPolicyModel
{
    [JsonPropertyName("blockSubscriptionsIntoTenant")]
    public bool? BlockSubscriptionsIntoTenant { get; set; }

    [JsonPropertyName("blockSubscriptionsLeavingTenant")]
    public bool? BlockSubscriptionsLeavingTenant { get; set; }

    [JsonPropertyName("exemptedPrincipals")]
    public List<string>? ExemptedPrincipals { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }
}
