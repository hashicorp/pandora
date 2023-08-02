// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class InvitationModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inviteRedeemUrl")]
    public string? InviteRedeemUrl { get; set; }

    [JsonPropertyName("inviteRedirectUrl")]
    public string? InviteRedirectUrl { get; set; }

    [JsonPropertyName("invitedUser")]
    public UserModel? InvitedUser { get; set; }

    [JsonPropertyName("invitedUserDisplayName")]
    public string? InvitedUserDisplayName { get; set; }

    [JsonPropertyName("invitedUserEmailAddress")]
    public string? InvitedUserEmailAddress { get; set; }

    [JsonPropertyName("invitedUserMessageInfo")]
    public InvitedUserMessageInfoModel? InvitedUserMessageInfo { get; set; }

    [JsonPropertyName("invitedUserType")]
    public string? InvitedUserType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resetRedemption")]
    public bool? ResetRedemption { get; set; }

    [JsonPropertyName("sendInvitationMessage")]
    public bool? SendInvitationMessage { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
