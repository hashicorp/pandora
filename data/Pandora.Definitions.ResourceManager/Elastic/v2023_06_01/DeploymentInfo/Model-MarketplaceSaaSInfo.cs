using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.DeploymentInfo;


internal class MarketplaceSaaSInfoModel
{
    [JsonPropertyName("marketplaceName")]
    public string? MarketplaceName { get; set; }

    [JsonPropertyName("marketplaceResourceId")]
    public string? MarketplaceResourceId { get; set; }

    [JsonPropertyName("marketplaceStatus")]
    public string? MarketplaceStatus { get; set; }

    [JsonPropertyName("marketplaceSubscription")]
    public MarketplaceSaaSInfoMarketplaceSubscriptionModel? MarketplaceSubscription { get; set; }
}
