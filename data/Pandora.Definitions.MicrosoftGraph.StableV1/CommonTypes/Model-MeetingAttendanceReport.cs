// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MeetingAttendanceReportModel
{
    [JsonPropertyName("attendanceRecords")]
    public List<AttendanceRecordModel>? AttendanceRecords { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("meetingEndDateTime")]
    public DateTime? MeetingEndDateTime { get; set; }

    [JsonPropertyName("meetingStartDateTime")]
    public DateTime? MeetingStartDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalParticipantCount")]
    public int? TotalParticipantCount { get; set; }
}
