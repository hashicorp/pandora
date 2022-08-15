using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.UsageDetails;


internal class LegacyUsageDetailPropertiesModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("accountOwnerId")]
    public string? AccountOwnerId { get; set; }

    [JsonPropertyName("additionalInfo")]
    public string? AdditionalInfo { get; set; }

    [JsonPropertyName("billingAccountId")]
    public string? BillingAccountId { get; set; }

    [JsonPropertyName("billingAccountName")]
    public string? BillingAccountName { get; set; }

    [JsonPropertyName("billingCurrency")]
    public string? BillingCurrency { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("billingPeriodEndDate")]
    public DateTime? BillingPeriodEndDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("billingPeriodStartDate")]
    public DateTime? BillingPeriodStartDate { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [JsonPropertyName("billingProfileName")]
    public string? BillingProfileName { get; set; }

    [JsonPropertyName("chargeType")]
    public string? ChargeType { get; set; }

    [JsonPropertyName("consumedService")]
    public string? ConsumedService { get; set; }

    [JsonPropertyName("cost")]
    public float? Cost { get; set; }

    [JsonPropertyName("costCenter")]
    public string? CostCenter { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("effectivePrice")]
    public float? EffectivePrice { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("invoiceSection")]
    public string? InvoiceSection { get; set; }

    [JsonPropertyName("isAzureCreditEligible")]
    public bool? IsAzureCreditEligible { get; set; }

    [JsonPropertyName("meterDetails")]
    public MeterDetailsResponseModel? MeterDetails { get; set; }

    [JsonPropertyName("meterId")]
    public string? MeterId { get; set; }

    [JsonPropertyName("offerId")]
    public string? OfferId { get; set; }

    [JsonPropertyName("partNumber")]
    public string? PartNumber { get; set; }

    [JsonPropertyName("planName")]
    public string? PlanName { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("productOrderId")]
    public string? ProductOrderId { get; set; }

    [JsonPropertyName("productOrderName")]
    public string? ProductOrderName { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }

    [JsonPropertyName("publisherType")]
    public string? PublisherType { get; set; }

    [JsonPropertyName("quantity")]
    public float? Quantity { get; set; }

    [JsonPropertyName("reservationId")]
    public string? ReservationId { get; set; }

    [JsonPropertyName("reservationName")]
    public string? ReservationName { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceLocation")]
    public string? ResourceLocation { get; set; }

    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    [JsonPropertyName("serviceInfo1")]
    public string? ServiceInfo1 { get; set; }

    [JsonPropertyName("serviceInfo2")]
    public string? ServiceInfo2 { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("subscriptionName")]
    public string? SubscriptionName { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }

    [JsonPropertyName("unitPrice")]
    public float? UnitPrice { get; set; }
}
