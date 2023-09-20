// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CalendarModel
{
    [JsonPropertyName("allowedOnlineMeetingProviders")]
    public List<CalendarAllowedOnlineMeetingProvidersConstant>? AllowedOnlineMeetingProviders { get; set; }

    [JsonPropertyName("calendarPermissions")]
    public List<CalendarPermissionModel>? CalendarPermissions { get; set; }

    [JsonPropertyName("calendarView")]
    public List<EventModel>? CalendarView { get; set; }

    [JsonPropertyName("canEdit")]
    public bool? CanEdit { get; set; }

    [JsonPropertyName("canShare")]
    public bool? CanShare { get; set; }

    [JsonPropertyName("canViewPrivateItems")]
    public bool? CanViewPrivateItems { get; set; }

    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("color")]
    public CalendarColorConstant? Color { get; set; }

    [JsonPropertyName("defaultOnlineMeetingProvider")]
    public CalendarDefaultOnlineMeetingProviderConstant? DefaultOnlineMeetingProvider { get; set; }

    [JsonPropertyName("events")]
    public List<EventModel>? Events { get; set; }

    [JsonPropertyName("hexColor")]
    public string? HexColor { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefaultCalendar")]
    public bool? IsDefaultCalendar { get; set; }

    [JsonPropertyName("isRemovable")]
    public bool? IsRemovable { get; set; }

    [JsonPropertyName("isTallyingResponses")]
    public bool? IsTallyingResponses { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public EmailAddressModel? Owner { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }
}
