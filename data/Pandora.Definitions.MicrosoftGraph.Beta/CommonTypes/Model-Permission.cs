// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionModel
{
    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("grantedTo")]
    public IdentitySetModel? GrantedTo { get; set; }

    [JsonPropertyName("grantedToIdentities")]
    public List<IdentitySetModel>? GrantedToIdentities { get; set; }

    [JsonPropertyName("grantedToIdentitiesV2")]
    public List<SharePointIdentitySetModel>? GrantedToIdentitiesV2 { get; set; }

    [JsonPropertyName("grantedToV2")]
    public SharePointIdentitySetModel? GrantedToV2 { get; set; }

    [JsonPropertyName("hasPassword")]
    public bool? HasPassword { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inheritedFrom")]
    public ItemReferenceModel? InheritedFrom { get; set; }

    [JsonPropertyName("invitation")]
    public SharingInvitationModel? Invitation { get; set; }

    [JsonPropertyName("link")]
    public SharingLinkModel? Link { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }

    [JsonPropertyName("shareId")]
    public string? ShareId { get; set; }
}
