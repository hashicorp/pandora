// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ContactModel
{
    [JsonPropertyName("assistantName")]
    public string? AssistantName { get; set; }

    [JsonPropertyName("birthday")]
    public DateTime? Birthday { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("children")]
    public List<string>? Children { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("emailAddresses")]
    public List<TypedEmailAddressModel>? EmailAddresses { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("fileAs")]
    public string? FileAs { get; set; }

    [JsonPropertyName("flag")]
    public FollowupFlagModel? Flag { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("generation")]
    public string? Generation { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("imAddresses")]
    public List<string>? ImAddresses { get; set; }

    [JsonPropertyName("initials")]
    public string? Initials { get; set; }

    [JsonPropertyName("isFavorite")]
    public bool? IsFavorite { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("manager")]
    public string? Manager { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("nickName")]
    public string? NickName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }

    [JsonPropertyName("parentFolderId")]
    public string? ParentFolderId { get; set; }

    [JsonPropertyName("personalNotes")]
    public string? PersonalNotes { get; set; }

    [JsonPropertyName("phones")]
    public List<PhoneModel>? Phones { get; set; }

    [JsonPropertyName("photo")]
    public ProfilePhotoModel? Photo { get; set; }

    [JsonPropertyName("postalAddresses")]
    public List<PhysicalAddressModel>? PostalAddresses { get; set; }

    [JsonPropertyName("profession")]
    public string? Profession { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }

    [JsonPropertyName("spouseName")]
    public string? SpouseName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("websites")]
    public List<WebsiteModel>? Websites { get; set; }

    [JsonPropertyName("weddingAnniversary")]
    public DateTime? WeddingAnniversary { get; set; }

    [JsonPropertyName("yomiCompanyName")]
    public string? YomiCompanyName { get; set; }

    [JsonPropertyName("yomiGivenName")]
    public string? YomiGivenName { get; set; }

    [JsonPropertyName("yomiSurname")]
    public string? YomiSurname { get; set; }
}
