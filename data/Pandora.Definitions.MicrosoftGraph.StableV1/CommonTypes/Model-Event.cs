// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EventModel
{
    [JsonPropertyName("allowNewTimeProposals")]
    public bool? AllowNewTimeProposals { get; set; }

    [JsonPropertyName("attachments")]
    public List<AttachmentModel>? Attachments { get; set; }

    [JsonPropertyName("attendees")]
    public List<AttendeeModel>? Attendees { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("bodyPreview")]
    public string? BodyPreview { get; set; }

    [JsonPropertyName("calendar")]
    public CalendarModel? Calendar { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("end")]
    public DateTimeTimeZoneModel? End { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("hideAttendees")]
    public bool? HideAttendees { get; set; }

    [JsonPropertyName("iCalUId")]
    public string? ICalUId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importance")]
    public ImportanceConstant? Importance { get; set; }

    [JsonPropertyName("instances")]
    public List<EventModel>? Instances { get; set; }

    [JsonPropertyName("isAllDay")]
    public bool? IsAllDay { get; set; }

    [JsonPropertyName("isCancelled")]
    public bool? IsCancelled { get; set; }

    [JsonPropertyName("isDraft")]
    public bool? IsDraft { get; set; }

    [JsonPropertyName("isOnlineMeeting")]
    public bool? IsOnlineMeeting { get; set; }

    [JsonPropertyName("isOrganizer")]
    public bool? IsOrganizer { get; set; }

    [JsonPropertyName("isReminderOn")]
    public bool? IsReminderOn { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("location")]
    public LocationModel? Location { get; set; }

    [JsonPropertyName("locations")]
    public List<LocationModel>? Locations { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onlineMeeting")]
    public OnlineMeetingInfoModel? OnlineMeeting { get; set; }

    [JsonPropertyName("onlineMeetingProvider")]
    public OnlineMeetingProviderTypeConstant? OnlineMeetingProvider { get; set; }

    [JsonPropertyName("onlineMeetingUrl")]
    public string? OnlineMeetingUrl { get; set; }

    [JsonPropertyName("organizer")]
    public RecipientModel? Organizer { get; set; }

    [JsonPropertyName("originalEndTimeZone")]
    public string? OriginalEndTimeZone { get; set; }

    [JsonPropertyName("originalStart")]
    public DateTime? OriginalStart { get; set; }

    [JsonPropertyName("originalStartTimeZone")]
    public string? OriginalStartTimeZone { get; set; }

    [JsonPropertyName("recurrence")]
    public PatternedRecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("reminderMinutesBeforeStart")]
    public int? ReminderMinutesBeforeStart { get; set; }

    [JsonPropertyName("responseRequested")]
    public bool? ResponseRequested { get; set; }

    [JsonPropertyName("responseStatus")]
    public ResponseStatusModel? ResponseStatus { get; set; }

    [JsonPropertyName("sensitivity")]
    public SensitivityConstant? Sensitivity { get; set; }

    [JsonPropertyName("seriesMasterId")]
    public string? SeriesMasterId { get; set; }

    [JsonPropertyName("showAs")]
    public FreeBusyStatusConstant? ShowAs { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }

    [JsonPropertyName("start")]
    public DateTimeTimeZoneModel? Start { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("type")]
    public EventTypeConstant? Type { get; set; }

    [JsonPropertyName("webLink")]
    public string? WebLink { get; set; }
}
