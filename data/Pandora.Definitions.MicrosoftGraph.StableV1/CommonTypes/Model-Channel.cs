// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChannelModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("filesFolder")]
    public DriveItemModel? FilesFolder { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isFavoriteByDefault")]
    public bool? IsFavoriteByDefault { get; set; }

    [JsonPropertyName("members")]
    public List<ConversationMemberModel>? Members { get; set; }

    [JsonPropertyName("membershipType")]
    public ChannelMembershipTypeConstant? MembershipType { get; set; }

    [JsonPropertyName("messages")]
    public List<ChatMessageModel>? Messages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sharedWithTeams")]
    public List<SharedWithChannelTeamInfoModel>? SharedWithTeams { get; set; }

    [JsonPropertyName("summary")]
    public ChannelSummaryModel? Summary { get; set; }

    [JsonPropertyName("tabs")]
    public List<TeamsTabModel>? Tabs { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
