// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PersonCertificationModel
{
    [JsonPropertyName("allowedAudiences")]
    public PersonCertificationAllowedAudiencesConstant? AllowedAudiences { get; set; }

    [JsonPropertyName("certificationId")]
    public string? CertificationId { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inference")]
    public InferenceDataModel? Inference { get; set; }

    [JsonPropertyName("isSearchable")]
    public bool? IsSearchable { get; set; }

    [JsonPropertyName("issuedDate")]
    public DateTime? IssuedDate { get; set; }

    [JsonPropertyName("issuingAuthority")]
    public string? IssuingAuthority { get; set; }

    [JsonPropertyName("issuingCompany")]
    public string? IssuingCompany { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("source")]
    public PersonDataSourcesModel? Source { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("thumbnailUrl")]
    public string? ThumbnailUrl { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
