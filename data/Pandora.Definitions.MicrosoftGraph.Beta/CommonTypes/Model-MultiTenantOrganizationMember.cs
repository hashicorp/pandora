// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MultiTenantOrganizationMemberModel
{
    [JsonPropertyName("addedByTenantId")]
    public string? AddedByTenantId { get; set; }

    [JsonPropertyName("addedDateTime")]
    public DateTime? AddedDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("joinedDateTime")]
    public DateTime? JoinedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("role")]
    public MultiTenantOrganizationMemberRoleConstant? Role { get; set; }

    [JsonPropertyName("state")]
    public MultiTenantOrganizationMemberStateConstant? State { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("transitionDetails")]
    public MultiTenantOrganizationMemberTransitionDetailsModel? TransitionDetails { get; set; }
}
