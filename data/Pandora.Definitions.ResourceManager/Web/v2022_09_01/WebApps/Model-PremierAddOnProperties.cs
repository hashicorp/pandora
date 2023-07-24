using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class PremierAddOnPropertiesModel
{
    [JsonPropertyName("marketplaceOffer")]
    public string? MarketplaceOffer { get; set; }

    [JsonPropertyName("marketplacePublisher")]
    public string? MarketplacePublisher { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }
}
