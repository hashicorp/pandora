// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class BookingBusinessModel
{
    [JsonPropertyName("address")]
    public PhysicalAddressModel? Address { get; set; }

    [JsonPropertyName("appointments")]
    public List<BookingAppointmentModel>? Appointments { get; set; }

    [JsonPropertyName("businessHours")]
    public List<BookingWorkHoursModel>? BusinessHours { get; set; }

    [JsonPropertyName("businessType")]
    public string? BusinessType { get; set; }

    [JsonPropertyName("calendarView")]
    public List<BookingAppointmentModel>? CalendarView { get; set; }

    [JsonPropertyName("customQuestions")]
    public List<BookingCustomQuestionModel>? CustomQuestions { get; set; }

    [JsonPropertyName("customers")]
    public List<BookingCustomerBaseModel>? Customers { get; set; }

    [JsonPropertyName("defaultCurrencyIso")]
    public string? DefaultCurrencyIso { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isPublished")]
    public bool? IsPublished { get; set; }

    [JsonPropertyName("languageTag")]
    public string? LanguageTag { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("publicUrl")]
    public string? PublicUrl { get; set; }

    [JsonPropertyName("schedulingPolicy")]
    public BookingSchedulingPolicyModel? SchedulingPolicy { get; set; }

    [JsonPropertyName("services")]
    public List<BookingServiceModel>? Services { get; set; }

    [JsonPropertyName("staffMembers")]
    public List<BookingStaffMemberBaseModel>? StaffMembers { get; set; }

    [JsonPropertyName("webSiteUrl")]
    public string? WebSiteUrl { get; set; }
}
