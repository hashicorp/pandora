using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;


internal class SubscriptionPoliciesModel
{
    [JsonPropertyName("locationPlacementId")]
    public string? LocationPlacementId { get; set; }

    [JsonPropertyName("quotaId")]
    public string? QuotaId { get; set; }

    [JsonPropertyName("spendingLimit")]
    public SpendingLimitConstant? SpendingLimit { get; set; }
}
