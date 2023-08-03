// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecureScoreControlProfileModel
{
    [JsonPropertyName("actionType")]
    public string? ActionType { get; set; }

    [JsonPropertyName("actionUrl")]
    public string? ActionUrl { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("complianceInformation")]
    public List<ComplianceInformationModel>? ComplianceInformation { get; set; }

    [JsonPropertyName("controlCategory")]
    public string? ControlCategory { get; set; }

    [JsonPropertyName("controlStateUpdates")]
    public List<SecureScoreControlStateUpdateModel>? ControlStateUpdates { get; set; }

    [JsonPropertyName("deprecated")]
    public bool? Deprecated { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("implementationCost")]
    public string? ImplementationCost { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    [JsonPropertyName("remediation")]
    public string? Remediation { get; set; }

    [JsonPropertyName("remediationImpact")]
    public string? RemediationImpact { get; set; }

    [JsonPropertyName("service")]
    public string? Service { get; set; }

    [JsonPropertyName("threats")]
    public List<string>? Threats { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("userImpact")]
    public string? UserImpact { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
