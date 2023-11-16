// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnlineMeetingBaseModel
{
    [JsonPropertyName("allowAttendeeToEnableCamera")]
    public bool? AllowAttendeeToEnableCamera { get; set; }

    [JsonPropertyName("allowAttendeeToEnableMic")]
    public bool? AllowAttendeeToEnableMic { get; set; }

    [JsonPropertyName("allowMeetingChat")]
    public OnlineMeetingBaseAllowMeetingChatConstant? AllowMeetingChat { get; set; }

    [JsonPropertyName("allowParticipantsToChangeName")]
    public bool? AllowParticipantsToChangeName { get; set; }

    [JsonPropertyName("allowRecording")]
    public bool? AllowRecording { get; set; }

    [JsonPropertyName("allowTeamworkReactions")]
    public bool? AllowTeamworkReactions { get; set; }

    [JsonPropertyName("allowTranscription")]
    public bool? AllowTranscription { get; set; }

    [JsonPropertyName("allowedPresenters")]
    public OnlineMeetingBaseAllowedPresentersConstant? AllowedPresenters { get; set; }

    [JsonPropertyName("anonymizeIdentityForRoles")]
    public List<OnlineMeetingBaseAnonymizeIdentityForRolesConstant>? AnonymizeIdentityForRoles { get; set; }

    [JsonPropertyName("attendanceReports")]
    public List<MeetingAttendanceReportModel>? AttendanceReports { get; set; }

    [JsonPropertyName("audioConferencing")]
    public AudioConferencingModel? AudioConferencing { get; set; }

    [JsonPropertyName("chatInfo")]
    public ChatInfoModel? ChatInfo { get; set; }

    [JsonPropertyName("chatRestrictions")]
    public ChatRestrictionsModel? ChatRestrictions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEndToEndEncryptionEnabled")]
    public bool? IsEndToEndEncryptionEnabled { get; set; }

    [JsonPropertyName("isEntryExitAnnounced")]
    public bool? IsEntryExitAnnounced { get; set; }

    [JsonPropertyName("joinInformation")]
    public ItemBodyModel? JoinInformation { get; set; }

    [JsonPropertyName("joinMeetingIdSettings")]
    public JoinMeetingIdSettingsModel? JoinMeetingIdSettings { get; set; }

    [JsonPropertyName("joinWebUrl")]
    public string? JoinWebUrl { get; set; }

    [JsonPropertyName("lobbyBypassSettings")]
    public LobbyBypassSettingsModel? LobbyBypassSettings { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recordAutomatically")]
    public bool? RecordAutomatically { get; set; }

    [JsonPropertyName("shareMeetingChatHistoryDefault")]
    public OnlineMeetingBaseShareMeetingChatHistoryDefaultConstant? ShareMeetingChatHistoryDefault { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("videoTeleconferenceId")]
    public string? VideoTeleconferenceId { get; set; }

    [JsonPropertyName("watermarkProtection")]
    public WatermarkProtectionValuesModel? WatermarkProtection { get; set; }
}
