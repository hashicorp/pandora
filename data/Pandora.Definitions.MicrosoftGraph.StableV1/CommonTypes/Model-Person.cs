// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PersonModel
{
    [JsonPropertyName("birthday")]
    public string? Birthday { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("imAddress")]
    public string? ImAddress { get; set; }

    [JsonPropertyName("isFavorite")]
    public bool? IsFavorite { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }

    [JsonPropertyName("personNotes")]
    public string? PersonNotes { get; set; }

    [JsonPropertyName("personType")]
    public PersonTypeModel? PersonType { get; set; }

    [JsonPropertyName("phones")]
    public List<PhoneModel>? Phones { get; set; }

    [JsonPropertyName("postalAddresses")]
    public List<LocationModel>? PostalAddresses { get; set; }

    [JsonPropertyName("profession")]
    public string? Profession { get; set; }

    [JsonPropertyName("scoredEmailAddresses")]
    public List<ScoredEmailAddressModel>? ScoredEmailAddresses { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("websites")]
    public List<WebsiteModel>? Websites { get; set; }

    [JsonPropertyName("yomiCompany")]
    public string? YomiCompany { get; set; }
}
