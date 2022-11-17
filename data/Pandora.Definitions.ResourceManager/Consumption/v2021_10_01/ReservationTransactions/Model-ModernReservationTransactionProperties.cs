using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationTransactions;


internal class ModernReservationTransactionPropertiesModel
{
    [JsonPropertyName("amount")]
    public float? Amount { get; set; }

    [JsonPropertyName("armSkuName")]
    public string? ArmSkuName { get; set; }

    [JsonPropertyName("billingFrequency")]
    public string? BillingFrequency { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [JsonPropertyName("billingProfileName")]
    public string? BillingProfileName { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventDate")]
    public DateTime? EventDate { get; set; }

    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    [JsonPropertyName("invoice")]
    public string? Invoice { get; set; }

    [JsonPropertyName("invoiceId")]
    public string? InvoiceId { get; set; }

    [JsonPropertyName("invoiceSectionId")]
    public string? InvoiceSectionId { get; set; }

    [JsonPropertyName("invoiceSectionName")]
    public string? InvoiceSectionName { get; set; }

    [JsonPropertyName("purchasingSubscriptionGuid")]
    public string? PurchasingSubscriptionGuid { get; set; }

    [JsonPropertyName("purchasingSubscriptionName")]
    public string? PurchasingSubscriptionName { get; set; }

    [JsonPropertyName("quantity")]
    public float? Quantity { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("reservationOrderId")]
    public string? ReservationOrderId { get; set; }

    [JsonPropertyName("reservationOrderName")]
    public string? ReservationOrderName { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }
}
