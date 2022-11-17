using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationTransactions;


internal class LegacyReservationTransactionPropertiesModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("accountOwnerEmail")]
    public string? AccountOwnerEmail { get; set; }

    [JsonPropertyName("amount")]
    public float? Amount { get; set; }

    [JsonPropertyName("armSkuName")]
    public string? ArmSkuName { get; set; }

    [JsonPropertyName("billingFrequency")]
    public string? BillingFrequency { get; set; }

    [JsonPropertyName("billingMonth")]
    public int? BillingMonth { get; set; }

    [JsonPropertyName("costCenter")]
    public string? CostCenter { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("currentEnrollment")]
    public string? CurrentEnrollment { get; set; }

    [JsonPropertyName("departmentName")]
    public string? DepartmentName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventDate")]
    public DateTime? EventDate { get; set; }

    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    [JsonPropertyName("monetaryCommitment")]
    public float? MonetaryCommitment { get; set; }

    [JsonPropertyName("overage")]
    public float? Overage { get; set; }

    [JsonPropertyName("purchasingEnrollment")]
    public string? PurchasingEnrollment { get; set; }

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
