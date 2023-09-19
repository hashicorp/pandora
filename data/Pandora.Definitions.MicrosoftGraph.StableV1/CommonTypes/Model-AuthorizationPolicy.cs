// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AuthorizationPolicyModel
{
    [JsonPropertyName("allowEmailVerifiedUsersToJoinOrganization")]
    public bool? AllowEmailVerifiedUsersToJoinOrganization { get; set; }

    [JsonPropertyName("allowInvitesFrom")]
    public AuthorizationPolicyAllowInvitesFromConstant? AllowInvitesFrom { get; set; }

    [JsonPropertyName("allowUserConsentForRiskyApps")]
    public bool? AllowUserConsentForRiskyApps { get; set; }

    [JsonPropertyName("allowedToSignUpEmailBasedSubscriptions")]
    public bool? AllowedToSignUpEmailBasedSubscriptions { get; set; }

    [JsonPropertyName("allowedToUseSSPR")]
    public bool? AllowedToUseSSPR { get; set; }

    [JsonPropertyName("blockMsolPowerShell")]
    public bool? BlockMsolPowerShell { get; set; }

    [JsonPropertyName("defaultUserRolePermissions")]
    public DefaultUserRolePermissionsModel? DefaultUserRolePermissions { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("guestUserRoleId")]
    public string? GuestUserRoleId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
