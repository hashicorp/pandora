// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class BookingStaffMemberModel
{
    [JsonPropertyName("availabilityIsAffectedByPersonalCalendar")]
    public bool? AvailabilityIsAffectedByPersonalCalendar { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEmailNotificationEnabled")]
    public bool? IsEmailNotificationEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("role")]
    public BookingStaffMemberRoleConstant? Role { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("useBusinessHours")]
    public bool? UseBusinessHours { get; set; }

    [JsonPropertyName("workingHours")]
    public List<BookingWorkHoursModel>? WorkingHours { get; set; }
}
