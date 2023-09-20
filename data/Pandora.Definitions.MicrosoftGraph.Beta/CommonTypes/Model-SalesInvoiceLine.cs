// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SalesInvoiceLineModel
{
    [JsonPropertyName("account")]
    public AccountModel? Account { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("amountExcludingTax")]
    public float? AmountExcludingTax { get; set; }

    [JsonPropertyName("amountIncludingTax")]
    public float? AmountIncludingTax { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discountAmount")]
    public float? DiscountAmount { get; set; }

    [JsonPropertyName("discountAppliedBeforeTax")]
    public bool? DiscountAppliedBeforeTax { get; set; }

    [JsonPropertyName("discountPercent")]
    public float? DiscountPercent { get; set; }

    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("invoiceDiscountAllocation")]
    public float? InvoiceDiscountAllocation { get; set; }

    [JsonPropertyName("item")]
    public ItemModel? Item { get; set; }

    [JsonPropertyName("itemId")]
    public string? ItemId { get; set; }

    [JsonPropertyName("lineType")]
    public string? LineType { get; set; }

    [JsonPropertyName("netAmount")]
    public float? NetAmount { get; set; }

    [JsonPropertyName("netAmountIncludingTax")]
    public float? NetAmountIncludingTax { get; set; }

    [JsonPropertyName("netTaxAmount")]
    public float? NetTaxAmount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("quantity")]
    public float? Quantity { get; set; }

    [JsonPropertyName("sequence")]
    public int? Sequence { get; set; }

    [JsonPropertyName("shipmentDate")]
    public DateTime? ShipmentDate { get; set; }

    [JsonPropertyName("taxCode")]
    public string? TaxCode { get; set; }

    [JsonPropertyName("taxPercent")]
    public float? TaxPercent { get; set; }

    [JsonPropertyName("totalTaxAmount")]
    public float? TotalTaxAmount { get; set; }

    [JsonPropertyName("unitOfMeasureId")]
    public string? UnitOfMeasureId { get; set; }

    [JsonPropertyName("unitPrice")]
    public float? UnitPrice { get; set; }
}
