// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ChatModel
{
    [JsonPropertyName("chatType")]
    public ChatChatTypeConstant? ChatType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("installedApps")]
    public List<TeamsAppInstallationModel>? InstalledApps { get; set; }

    [JsonPropertyName("lastMessagePreview")]
    public ChatMessageInfoModel? LastMessagePreview { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("members")]
    public List<ConversationMemberModel>? Members { get; set; }

    [JsonPropertyName("messages")]
    public List<ChatMessageModel>? Messages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onlineMeetingInfo")]
    public TeamworkOnlineMeetingInfoModel? OnlineMeetingInfo { get; set; }

    [JsonPropertyName("operations")]
    public List<TeamsAsyncOperationModel>? Operations { get; set; }

    [JsonPropertyName("permissionGrants")]
    public List<ResourceSpecificPermissionGrantModel>? PermissionGrants { get; set; }

    [JsonPropertyName("pinnedMessages")]
    public List<PinnedChatMessageInfoModel>? PinnedMessages { get; set; }

    [JsonPropertyName("tabs")]
    public List<TeamsTabModel>? Tabs { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("topic")]
    public string? Topic { get; set; }

    [JsonPropertyName("viewpoint")]
    public ChatViewpointModel? Viewpoint { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
