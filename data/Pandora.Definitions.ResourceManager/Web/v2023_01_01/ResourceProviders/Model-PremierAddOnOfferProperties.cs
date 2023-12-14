using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class PremierAddOnOfferPropertiesModel
{
    [JsonPropertyName("legalTermsUrl")]
    public string? LegalTermsUrl { get; set; }

    [JsonPropertyName("marketplaceOffer")]
    public string? MarketplaceOffer { get; set; }

    [JsonPropertyName("marketplacePublisher")]
    public string? MarketplacePublisher { get; set; }

    [JsonPropertyName("privacyPolicyUrl")]
    public string? PrivacyPolicyUrl { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("promoCodeRequired")]
    public bool? PromoCodeRequired { get; set; }

    [JsonPropertyName("quota")]
    public int? Quota { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("webHostingPlanRestrictions")]
    public AppServicePlanRestrictionsConstant? WebHostingPlanRestrictions { get; set; }
}
