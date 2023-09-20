// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallModel
{
    [JsonPropertyName("audioRoutingGroups")]
    public List<AudioRoutingGroupModel>? AudioRoutingGroups { get; set; }

    [JsonPropertyName("callChainId")]
    public string? CallChainId { get; set; }

    [JsonPropertyName("callOptions")]
    public CallOptionsModel? CallOptions { get; set; }

    [JsonPropertyName("callRoutes")]
    public List<CallRouteModel>? CallRoutes { get; set; }

    [JsonPropertyName("callbackUri")]
    public string? CallbackUri { get; set; }

    [JsonPropertyName("chatInfo")]
    public ChatInfoModel? ChatInfo { get; set; }

    [JsonPropertyName("contentSharingSessions")]
    public List<ContentSharingSessionModel>? ContentSharingSessions { get; set; }

    [JsonPropertyName("direction")]
    public CallDirectionConstant? Direction { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incomingContext")]
    public IncomingContextModel? IncomingContext { get; set; }

    [JsonPropertyName("mediaConfig")]
    public MediaConfigModel? MediaConfig { get; set; }

    [JsonPropertyName("mediaState")]
    public CallMediaStateModel? MediaState { get; set; }

    [JsonPropertyName("meetingInfo")]
    public MeetingInfoModel? MeetingInfo { get; set; }

    [JsonPropertyName("myParticipantId")]
    public string? MyParticipantId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<CommsOperationModel>? Operations { get; set; }

    [JsonPropertyName("participants")]
    public List<ParticipantModel>? Participants { get; set; }

    [JsonPropertyName("requestedModalities")]
    public List<CallRequestedModalitiesConstant>? RequestedModalities { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("source")]
    public ParticipantInfoModel? Source { get; set; }

    [JsonPropertyName("state")]
    public CallStateConstant? State { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("targets")]
    public List<InvitationParticipantInfoModel>? Targets { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("toneInfo")]
    public ToneInfoModel? ToneInfo { get; set; }

    [JsonPropertyName("transcription")]
    public CallTranscriptionInfoModel? Transcription { get; set; }
}
