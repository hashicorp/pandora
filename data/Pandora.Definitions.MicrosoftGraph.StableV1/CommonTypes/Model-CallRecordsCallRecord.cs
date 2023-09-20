// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordsCallRecordModel
{
    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("joinWebUrl")]
    public string? JoinWebUrl { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("modalities")]
    public List<CallRecordsCallRecordModalitiesConstant>? Modalities { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizer")]
    public IdentitySetModel? Organizer { get; set; }

    [JsonPropertyName("participants")]
    public List<IdentitySetModel>? Participants { get; set; }

    [JsonPropertyName("sessions")]
    public List<CallRecordsSessionModel>? Sessions { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("type")]
    public CallRecordsCallRecordTypeConstant? Type { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
