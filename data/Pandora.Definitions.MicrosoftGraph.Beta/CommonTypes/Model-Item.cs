// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ItemModel
{
    [JsonPropertyName("baseUnitOfMeasureId")]
    public string? BaseUnitOfMeasureId { get; set; }

    [JsonPropertyName("blocked")]
    public bool? Blocked { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("gtin")]
    public string? Gtin { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inventory")]
    public float? Inventory { get; set; }

    [JsonPropertyName("itemCategory")]
    public ItemCategoryModel? ItemCategory { get; set; }

    [JsonPropertyName("itemCategoryCode")]
    public string? ItemCategoryCode { get; set; }

    [JsonPropertyName("itemCategoryId")]
    public string? ItemCategoryId { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("picture")]
    public List<PictureModel>? Picture { get; set; }

    [JsonPropertyName("priceIncludesTax")]
    public bool? PriceIncludesTax { get; set; }

    [JsonPropertyName("taxGroupCode")]
    public string? TaxGroupCode { get; set; }

    [JsonPropertyName("taxGroupId")]
    public string? TaxGroupId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("unitCost")]
    public float? UnitCost { get; set; }

    [JsonPropertyName("unitPrice")]
    public float? UnitPrice { get; set; }
}
