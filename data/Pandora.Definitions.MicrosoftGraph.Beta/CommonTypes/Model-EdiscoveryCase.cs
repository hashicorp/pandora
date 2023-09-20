// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EdiscoveryCaseModel
{
    [JsonPropertyName("closedBy")]
    public IdentitySetModel? ClosedBy { get; set; }

    [JsonPropertyName("closedDateTime")]
    public DateTime? ClosedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("custodians")]
    public List<EdiscoveryCustodianModel>? Custodians { get; set; }

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
    public List<EdiscoveryLegalHoldModel>? LegalHolds { get; set; }

    [JsonPropertyName("noncustodialDataSources")]
    public List<EdiscoveryNoncustodialDataSourceModel>? NoncustodialDataSources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<EdiscoveryCaseOperationModel>? Operations { get; set; }

    [JsonPropertyName("reviewSets")]
    public List<EdiscoveryReviewSetModel>? ReviewSets { get; set; }

    [JsonPropertyName("settings")]
    public EdiscoveryCaseSettingsModel? Settings { get; set; }

    [JsonPropertyName("sourceCollections")]
    public List<EdiscoverySourceCollectionModel>? SourceCollections { get; set; }

    [JsonPropertyName("status")]
    public EdiscoveryCaseStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public List<EdiscoveryTagModel>? Tags { get; set; }
}
