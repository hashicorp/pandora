// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VppTokenModel
{
    [JsonPropertyName("appleId")]
    public string? AppleId { get; set; }

    [JsonPropertyName("automaticallyUpdateApps")]
    public bool? AutomaticallyUpdateApps { get; set; }

    [JsonPropertyName("claimTokenManagementFromExternalMdm")]
    public bool? ClaimTokenManagementFromExternalMdm { get; set; }

    [JsonPropertyName("countryOrRegion")]
    public string? CountryOrRegion { get; set; }

    [JsonPropertyName("dataSharingConsentGranted")]
    public bool? DataSharingConsentGranted { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("lastSyncStatus")]
    public VppTokenSyncStatusConstant? LastSyncStatus { get; set; }

    [JsonPropertyName("locationName")]
    public string? LocationName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizationName")]
    public string? OrganizationName { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("state")]
    public VppTokenStateConstant? State { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("tokenActionResults")]
    public List<VppTokenActionResultModel>? TokenActionResults { get; set; }

    [JsonPropertyName("vppTokenAccountType")]
    public VppTokenAccountTypeConstant? VppTokenAccountType { get; set; }
}
