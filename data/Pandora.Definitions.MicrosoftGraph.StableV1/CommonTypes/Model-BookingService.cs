// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class BookingServiceModel
{
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    [JsonPropertyName("customQuestions")]
    public List<BookingQuestionAssignmentModel>? CustomQuestions { get; set; }

    [JsonPropertyName("defaultDuration")]
    public string? DefaultDuration { get; set; }

    [JsonPropertyName("defaultLocation")]
    public LocationModel? DefaultLocation { get; set; }

    [JsonPropertyName("defaultPriceType")]
    public BookingPriceTypeConstant? DefaultPriceType { get; set; }

    [JsonPropertyName("defaultReminders")]
    public List<BookingReminderModel>? DefaultReminders { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAnonymousJoinEnabled")]
    public bool? IsAnonymousJoinEnabled { get; set; }

    [JsonPropertyName("isHiddenFromCustomers")]
    public bool? IsHiddenFromCustomers { get; set; }

    [JsonPropertyName("isLocationOnline")]
    public bool? IsLocationOnline { get; set; }

    [JsonPropertyName("languageTag")]
    public string? LanguageTag { get; set; }

    [JsonPropertyName("maximumAttendeesCount")]
    public int? MaximumAttendeesCount { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("postBuffer")]
    public string? PostBuffer { get; set; }

    [JsonPropertyName("preBuffer")]
    public string? PreBuffer { get; set; }

    [JsonPropertyName("schedulingPolicy")]
    public BookingSchedulingPolicyModel? SchedulingPolicy { get; set; }

    [JsonPropertyName("smsNotificationsEnabled")]
    public bool? SmsNotificationsEnabled { get; set; }

    [JsonPropertyName("staffMemberIds")]
    public List<string>? StaffMemberIds { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
