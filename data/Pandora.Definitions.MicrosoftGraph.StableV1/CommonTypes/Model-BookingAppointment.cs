// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class BookingAppointmentModel
{
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    [JsonPropertyName("anonymousJoinWebUrl")]
    public string? AnonymousJoinWebUrl { get; set; }

    [JsonPropertyName("customerTimeZone")]
    public string? CustomerTimeZone { get; set; }

    [JsonPropertyName("customers")]
    public List<BookingCustomerInformationBaseModel>? Customers { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTimeTimeZoneModel? EndDateTime { get; set; }

    [JsonPropertyName("filledAttendeesCount")]
    public int? FilledAttendeesCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isLocationOnline")]
    public bool? IsLocationOnline { get; set; }

    [JsonPropertyName("joinWebUrl")]
    public string? JoinWebUrl { get; set; }

    [JsonPropertyName("maximumAttendeesCount")]
    public int? MaximumAttendeesCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("optOutOfCustomerEmail")]
    public bool? OptOutOfCustomerEmail { get; set; }

    [JsonPropertyName("postBuffer")]
    public string? PostBuffer { get; set; }

    [JsonPropertyName("preBuffer")]
    public string? PreBuffer { get; set; }

    [JsonPropertyName("priceType")]
    public BookingPriceTypeConstant? PriceType { get; set; }

    [JsonPropertyName("reminders")]
    public List<BookingReminderModel>? Reminders { get; set; }

    [JsonPropertyName("selfServiceAppointmentId")]
    public string? SelfServiceAppointmentId { get; set; }

    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; set; }

    [JsonPropertyName("serviceLocation")]
    public LocationModel? ServiceLocation { get; set; }

    [JsonPropertyName("serviceName")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("serviceNotes")]
    public string? ServiceNotes { get; set; }

    [JsonPropertyName("smsNotificationsEnabled")]
    public bool? SmsNotificationsEnabled { get; set; }

    [JsonPropertyName("staffMemberIds")]
    public List<string>? StaffMemberIds { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZoneModel? StartDateTime { get; set; }
}
