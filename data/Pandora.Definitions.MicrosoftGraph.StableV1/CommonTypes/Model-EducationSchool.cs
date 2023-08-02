// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EducationSchoolModel
{
    [JsonPropertyName("address")]
    public PhysicalAddressModel? Address { get; set; }

    [JsonPropertyName("administrativeUnit")]
    public AdministrativeUnitModel? AdministrativeUnit { get; set; }

    [JsonPropertyName("classes")]
    public List<EducationClassModel>? Classes { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalPrincipalId")]
    public string? ExternalPrincipalId { get; set; }

    [JsonPropertyName("externalSource")]
    public EducationExternalSourceConstant? ExternalSource { get; set; }

    [JsonPropertyName("externalSourceDetail")]
    public string? ExternalSourceDetail { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("highestGrade")]
    public string? HighestGrade { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lowestGrade")]
    public string? LowestGrade { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("principalEmail")]
    public string? PrincipalEmail { get; set; }

    [JsonPropertyName("principalName")]
    public string? PrincipalName { get; set; }

    [JsonPropertyName("schoolNumber")]
    public string? SchoolNumber { get; set; }

    [JsonPropertyName("users")]
    public List<EducationUserModel>? Users { get; set; }
}
