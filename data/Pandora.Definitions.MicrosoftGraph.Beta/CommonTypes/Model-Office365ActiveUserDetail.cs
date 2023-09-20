// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Office365ActiveUserDetailModel
{
    [JsonPropertyName("assignedProducts")]
    public List<string>? AssignedProducts { get; set; }

    [JsonPropertyName("deletedDate")]
    public DateTime? DeletedDate { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("exchangeLastActivityDate")]
    public DateTime? ExchangeLastActivityDate { get; set; }

    [JsonPropertyName("exchangeLicenseAssignDate")]
    public DateTime? ExchangeLicenseAssignDate { get; set; }

    [JsonPropertyName("hasExchangeLicense")]
    public bool? HasExchangeLicense { get; set; }

    [JsonPropertyName("hasOneDriveLicense")]
    public bool? HasOneDriveLicense { get; set; }

    [JsonPropertyName("hasSharePointLicense")]
    public bool? HasSharePointLicense { get; set; }

    [JsonPropertyName("hasSkypeForBusinessLicense")]
    public bool? HasSkypeForBusinessLicense { get; set; }

    [JsonPropertyName("hasTeamsLicense")]
    public bool? HasTeamsLicense { get; set; }

    [JsonPropertyName("hasYammerLicense")]
    public bool? HasYammerLicense { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oneDriveLastActivityDate")]
    public DateTime? OneDriveLastActivityDate { get; set; }

    [JsonPropertyName("oneDriveLicenseAssignDate")]
    public DateTime? OneDriveLicenseAssignDate { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("sharePointLastActivityDate")]
    public DateTime? SharePointLastActivityDate { get; set; }

    [JsonPropertyName("sharePointLicenseAssignDate")]
    public DateTime? SharePointLicenseAssignDate { get; set; }

    [JsonPropertyName("skypeForBusinessLastActivityDate")]
    public DateTime? SkypeForBusinessLastActivityDate { get; set; }

    [JsonPropertyName("skypeForBusinessLicenseAssignDate")]
    public DateTime? SkypeForBusinessLicenseAssignDate { get; set; }

    [JsonPropertyName("teamsLastActivityDate")]
    public DateTime? TeamsLastActivityDate { get; set; }

    [JsonPropertyName("teamsLicenseAssignDate")]
    public DateTime? TeamsLicenseAssignDate { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("yammerLastActivityDate")]
    public DateTime? YammerLastActivityDate { get; set; }

    [JsonPropertyName("yammerLicenseAssignDate")]
    public DateTime? YammerLicenseAssignDate { get; set; }
}
