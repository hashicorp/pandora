// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Office365GroupsActivityDetailModel
{
    [JsonPropertyName("exchangeMailboxStorageUsedInBytes")]
    public long? ExchangeMailboxStorageUsedInBytes { get; set; }

    [JsonPropertyName("exchangeMailboxTotalItemCount")]
    public long? ExchangeMailboxTotalItemCount { get; set; }

    [JsonPropertyName("exchangeReceivedEmailCount")]
    public long? ExchangeReceivedEmailCount { get; set; }

    [JsonPropertyName("externalMemberCount")]
    public long? ExternalMemberCount { get; set; }

    [JsonPropertyName("groupDisplayName")]
    public string? GroupDisplayName { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("groupType")]
    public string? GroupType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("lastActivityDate")]
    public DateTime? LastActivityDate { get; set; }

    [JsonPropertyName("memberCount")]
    public long? MemberCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownerPrincipalName")]
    public string? OwnerPrincipalName { get; set; }

    [JsonPropertyName("reportPeriod")]
    public string? ReportPeriod { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("sharePointActiveFileCount")]
    public long? SharePointActiveFileCount { get; set; }

    [JsonPropertyName("sharePointSiteStorageUsedInBytes")]
    public long? SharePointSiteStorageUsedInBytes { get; set; }

    [JsonPropertyName("sharePointTotalFileCount")]
    public long? SharePointTotalFileCount { get; set; }

    [JsonPropertyName("teamsChannelMessagesCount")]
    public long? TeamsChannelMessagesCount { get; set; }

    [JsonPropertyName("teamsMeetingsOrganizedCount")]
    public long? TeamsMeetingsOrganizedCount { get; set; }

    [JsonPropertyName("yammerLikedMessageCount")]
    public long? YammerLikedMessageCount { get; set; }

    [JsonPropertyName("yammerPostedMessageCount")]
    public long? YammerPostedMessageCount { get; set; }

    [JsonPropertyName("yammerReadMessageCount")]
    public long? YammerReadMessageCount { get; set; }
}
