// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeamModel
{
    [JsonPropertyName("allChannels")]
    public List<ChannelModel>? AllChannels { get; set; }

    [JsonPropertyName("channels")]
    public List<ChannelModel>? Channels { get; set; }

    [JsonPropertyName("classification")]
    public string? Classification { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("funSettings")]
    public TeamFunSettingsModel? FunSettings { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("guestSettings")]
    public TeamGuestSettingsModel? GuestSettings { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incomingChannels")]
    public List<ChannelModel>? IncomingChannels { get; set; }

    [JsonPropertyName("installedApps")]
    public List<TeamsAppInstallationModel>? InstalledApps { get; set; }

    [JsonPropertyName("internalId")]
    public string? InternalId { get; set; }

    [JsonPropertyName("isArchived")]
    public bool? IsArchived { get; set; }

    [JsonPropertyName("memberSettings")]
    public TeamMemberSettingsModel? MemberSettings { get; set; }

    [JsonPropertyName("members")]
    public List<ConversationMemberModel>? Members { get; set; }

    [JsonPropertyName("messagingSettings")]
    public TeamMessagingSettingsModel? MessagingSettings { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<TeamsAsyncOperationModel>? Operations { get; set; }

    [JsonPropertyName("photo")]
    public ProfilePhotoModel? Photo { get; set; }

    [JsonPropertyName("primaryChannel")]
    public ChannelModel? PrimaryChannel { get; set; }

    [JsonPropertyName("schedule")]
    public ScheduleModel? Schedule { get; set; }

    [JsonPropertyName("specialization")]
    public TeamSpecializationConstant? Specialization { get; set; }

    [JsonPropertyName("summary")]
    public TeamSummaryModel? Summary { get; set; }

    [JsonPropertyName("tags")]
    public List<TeamworkTagModel>? Tags { get; set; }

    [JsonPropertyName("template")]
    public TeamsTemplateModel? Template { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("visibility")]
    public TeamVisibilityTypeConstant? Visibility { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
