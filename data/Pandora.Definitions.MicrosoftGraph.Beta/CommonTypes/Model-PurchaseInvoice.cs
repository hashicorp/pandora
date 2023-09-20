// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PurchaseInvoiceModel
{
    [JsonPropertyName("buyFromAddress")]
    public PostalAddressTypeModel? BuyFromAddress { get; set; }

    [JsonPropertyName("currency")]
    public CurrencyModel? Currency { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("currencyId")]
    public string? CurrencyId { get; set; }

    [JsonPropertyName("discountAmount")]
    public float? DiscountAmount { get; set; }

    [JsonPropertyName("discountAppliedBeforeTax")]
    public bool? DiscountAppliedBeforeTax { get; set; }

    [JsonPropertyName("dueDate")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("invoiceDate")]
    public DateTime? InvoiceDate { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payToAddress")]
    public PostalAddressTypeModel? PayToAddress { get; set; }

    [JsonPropertyName("payToContact")]
    public string? PayToContact { get; set; }

    [JsonPropertyName("payToName")]
    public string? PayToName { get; set; }

    [JsonPropertyName("payToVendorId")]
    public string? PayToVendorId { get; set; }

    [JsonPropertyName("payToVendorNumber")]
    public string? PayToVendorNumber { get; set; }

    [JsonPropertyName("pricesIncludeTax")]
    public bool? PricesIncludeTax { get; set; }

    [JsonPropertyName("purchaseInvoiceLines")]
    public List<PurchaseInvoiceLineModel>? PurchaseInvoiceLines { get; set; }

    [JsonPropertyName("shipToAddress")]
    public PostalAddressTypeModel? ShipToAddress { get; set; }

    [JsonPropertyName("shipToContact")]
    public string? ShipToContact { get; set; }

    [JsonPropertyName("shipToName")]
    public string? ShipToName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("totalAmountExcludingTax")]
    public float? TotalAmountExcludingTax { get; set; }

    [JsonPropertyName("totalAmountIncludingTax")]
    public float? TotalAmountIncludingTax { get; set; }

    [JsonPropertyName("totalTaxAmount")]
    public float? TotalTaxAmount { get; set; }

    [JsonPropertyName("vendor")]
    public VendorModel? Vendor { get; set; }

    [JsonPropertyName("vendorId")]
    public string? VendorId { get; set; }

    [JsonPropertyName("vendorInvoiceNumber")]
    public string? VendorInvoiceNumber { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }

    [JsonPropertyName("vendorNumber")]
    public string? VendorNumber { get; set; }
}
