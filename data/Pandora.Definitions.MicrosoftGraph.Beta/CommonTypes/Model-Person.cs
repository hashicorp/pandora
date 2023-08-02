// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

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

    [JsonPropertyName("emailAddresses")]
    public List<RankedEmailAddressModel>? EmailAddresses { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isFavorite")]
    public bool? IsFavorite { get; set; }

    [JsonPropertyName("mailboxType")]
    public string? MailboxType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }

    [JsonPropertyName("personNotes")]
    public string? PersonNotes { get; set; }

    [JsonPropertyName("personType")]
    public string? PersonType { get; set; }

    [JsonPropertyName("phones")]
    public List<PhoneModel>? Phones { get; set; }

    [JsonPropertyName("postalAddresses")]
    public List<LocationModel>? PostalAddresses { get; set; }

    [JsonPropertyName("profession")]
    public string? Profession { get; set; }

    [JsonPropertyName("sources")]
    public List<PersonDataSourceModel>? Sources { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("websites")]
    public List<WebsiteModel>? Websites { get; set; }

    [JsonPropertyName("yomiCompany")]
    public string? YomiCompany { get; set; }
}
