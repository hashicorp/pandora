// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationalActivityModel
{
    [JsonPropertyName("allowedAudiences")]
    public EducationalActivityAllowedAudiencesConstant? AllowedAudiences { get; set; }

    [JsonPropertyName("completionMonthYear")]
    public DateTime? CompletionMonthYear { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("endMonthYear")]
    public DateTime? EndMonthYear { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inference")]
    public InferenceDataModel? Inference { get; set; }

    [JsonPropertyName("institution")]
    public InstitutionDataModel? Institution { get; set; }

    [JsonPropertyName("isSearchable")]
    public bool? IsSearchable { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("program")]
    public EducationalActivityDetailModel? Program { get; set; }

    [JsonPropertyName("source")]
    public PersonDataSourcesModel? Source { get; set; }

    [JsonPropertyName("startMonthYear")]
    public DateTime? StartMonthYear { get; set; }
}
