// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SalesInvoiceModel
{
    [JsonPropertyName("billToCustomerId")]
    public string? BillToCustomerId { get; set; }

    [JsonPropertyName("billToCustomerNumber")]
    public string? BillToCustomerNumber { get; set; }

    [JsonPropertyName("billToName")]
    public string? BillToName { get; set; }

    [JsonPropertyName("billingPostalAddress")]
    public PostalAddressTypeModel? BillingPostalAddress { get; set; }

    [JsonPropertyName("currency")]
    public CurrencyModel? Currency { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("currencyId")]
    public string? CurrencyId { get; set; }

    [JsonPropertyName("customer")]
    public CustomerModel? Customer { get; set; }

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("customerName")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("customerPurchaseOrderReference")]
    public string? CustomerPurchaseOrderReference { get; set; }

    [JsonPropertyName("discountAmount")]
    public float? DiscountAmount { get; set; }

    [JsonPropertyName("discountAppliedBeforeTax")]
    public bool? DiscountAppliedBeforeTax { get; set; }

    [JsonPropertyName("dueDate")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalDocumentNumber")]
    public string? ExternalDocumentNumber { get; set; }

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

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("orderNumber")]
    public string? OrderNumber { get; set; }

    [JsonPropertyName("paymentTerm")]
    public PaymentTermModel? PaymentTerm { get; set; }

    [JsonPropertyName("paymentTermsId")]
    public string? PaymentTermsId { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("pricesIncludeTax")]
    public bool? PricesIncludeTax { get; set; }

    [JsonPropertyName("salesInvoiceLines")]
    public List<SalesInvoiceLineModel>? SalesInvoiceLines { get; set; }

    [JsonPropertyName("salesperson")]
    public string? Salesperson { get; set; }

    [JsonPropertyName("sellingPostalAddress")]
    public PostalAddressTypeModel? SellingPostalAddress { get; set; }

    [JsonPropertyName("shipToContact")]
    public string? ShipToContact { get; set; }

    [JsonPropertyName("shipToName")]
    public string? ShipToName { get; set; }

    [JsonPropertyName("shipmentMethod")]
    public ShipmentMethodModel? ShipmentMethod { get; set; }

    [JsonPropertyName("shipmentMethodId")]
    public string? ShipmentMethodId { get; set; }

    [JsonPropertyName("shippingPostalAddress")]
    public PostalAddressTypeModel? ShippingPostalAddress { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("totalAmountExcludingTax")]
    public float? TotalAmountExcludingTax { get; set; }

    [JsonPropertyName("totalAmountIncludingTax")]
    public float? TotalAmountIncludingTax { get; set; }

    [JsonPropertyName("totalTaxAmount")]
    public float? TotalTaxAmount { get; set; }
}
