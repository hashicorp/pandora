// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEdiscoveryCaseModel
{
    [JsonPropertyName("closedBy")]
    public IdentitySetModel? ClosedBy { get; set; }

    [JsonPropertyName("closedDateTime")]
    public DateTime? ClosedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("custodians")]
    public List<SecurityEdiscoveryCustodianModel>? Custodians { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("legalHolds")]
    public List<SecurityEdiscoveryHoldPolicyModel>? LegalHolds { get; set; }

    [JsonPropertyName("noncustodialDataSources")]
    public List<SecurityEdiscoveryNoncustodialDataSourceModel>? NoncustodialDataSources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<SecurityCaseOperationModel>? Operations { get; set; }

    [JsonPropertyName("reviewSets")]
    public List<SecurityEdiscoveryReviewSetModel>? ReviewSets { get; set; }

    [JsonPropertyName("searches")]
    public List<SecurityEdiscoverySearchModel>? Searches { get; set; }

    [JsonPropertyName("settings")]
    public SecurityEdiscoveryCaseSettingsModel? Settings { get; set; }

    [JsonPropertyName("status")]
    public SecurityEdiscoveryCaseStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public List<SecurityEdiscoveryReviewTagModel>? Tags { get; set; }
}
