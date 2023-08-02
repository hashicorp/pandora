// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ProfileModel
{
    [JsonPropertyName("account")]
    public List<UserAccountInformationModel>? Account { get; set; }

    [JsonPropertyName("addresses")]
    public List<ItemAddressModel>? Addresses { get; set; }

    [JsonPropertyName("anniversaries")]
    public List<PersonAnnualEventModel>? Anniversaries { get; set; }

    [JsonPropertyName("awards")]
    public List<PersonAwardModel>? Awards { get; set; }

    [JsonPropertyName("certifications")]
    public List<PersonCertificationModel>? Certifications { get; set; }

    [JsonPropertyName("educationalActivities")]
    public List<EducationalActivityModel>? EducationalActivities { get; set; }

    [JsonPropertyName("emails")]
    public List<ItemEmailModel>? Emails { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("interests")]
    public List<PersonInterestModel>? Interests { get; set; }

    [JsonPropertyName("languages")]
    public List<LanguageProficiencyModel>? Languages { get; set; }

    [JsonPropertyName("names")]
    public List<PersonNameModel>? Names { get; set; }

    [JsonPropertyName("notes")]
    public List<PersonAnnotationModel>? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("patents")]
    public List<ItemPatentModel>? Patents { get; set; }

    [JsonPropertyName("phones")]
    public List<ItemPhoneModel>? Phones { get; set; }

    [JsonPropertyName("positions")]
    public List<WorkPositionModel>? Positions { get; set; }

    [JsonPropertyName("projects")]
    public List<ProjectParticipationModel>? Projects { get; set; }

    [JsonPropertyName("publications")]
    public List<ItemPublicationModel>? Publications { get; set; }

    [JsonPropertyName("skills")]
    public List<SkillProficiencyModel>? Skills { get; set; }

    [JsonPropertyName("webAccounts")]
    public List<WebAccountModel>? WebAccounts { get; set; }

    [JsonPropertyName("websites")]
    public List<PersonWebsiteModel>? Websites { get; set; }
}
