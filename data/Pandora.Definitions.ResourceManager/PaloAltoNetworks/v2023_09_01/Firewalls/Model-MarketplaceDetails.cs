using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;


internal class MarketplaceDetailsModel
{
    [JsonPropertyName("marketplaceSubscriptionId")]
    public string? MarketplaceSubscriptionId { get; set; }

    [JsonPropertyName("marketplaceSubscriptionStatus")]
    public MarketplaceSubscriptionStatusConstant? MarketplaceSubscriptionStatus { get; set; }

    [JsonPropertyName("offerId")]
    [Required]
    public string OfferId { get; set; }

    [JsonPropertyName("publisherId")]
    [Required]
    public string PublisherId { get; set; }
}
