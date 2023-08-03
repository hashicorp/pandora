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
    public List<CustodianModel>? Custodians { get; set; }

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
    public List<LegalHoldModel>? LegalHolds { get; set; }

    [JsonPropertyName("noncustodialDataSources")]
    public List<NoncustodialDataSourceModel>? NoncustodialDataSources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<CaseOperationModel>? Operations { get; set; }

    [JsonPropertyName("reviewSets")]
    public List<ReviewSetModel>? ReviewSets { get; set; }

    [JsonPropertyName("settings")]
    public CaseSettingsModel? Settings { get; set; }

    [JsonPropertyName("sourceCollections")]
    public List<SourceCollectionModel>? SourceCollections { get; set; }

    [JsonPropertyName("status")]
    public CaseStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public List<TagModel>? Tags { get; set; }
}
