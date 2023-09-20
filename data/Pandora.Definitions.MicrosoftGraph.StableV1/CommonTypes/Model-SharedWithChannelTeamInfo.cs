// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharedWithChannelTeamInfoModel
{
    [JsonPropertyName("allowedMembers")]
    public List<ConversationMemberModel>? AllowedMembers { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isHostTeam")]
    public bool? IsHostTeam { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("team")]
    public TeamModel? Team { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
