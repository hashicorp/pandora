// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationUserModel
{
    [JsonPropertyName("accountEnabled")]
    public bool? AccountEnabled { get; set; }

    [JsonPropertyName("assignedLicenses")]
    public List<AssignedLicenseModel>? AssignedLicenses { get; set; }

    [JsonPropertyName("assignedPlans")]
    public List<AssignedPlanModel>? AssignedPlans { get; set; }

    [JsonPropertyName("assignments")]
    public List<EducationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("businessPhones")]
    public List<string>? BusinessPhones { get; set; }

    [JsonPropertyName("classes")]
    public List<EducationClassModel>? Classes { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("externalSource")]
    public EducationUserExternalSourceConstant? ExternalSource { get; set; }

    [JsonPropertyName("externalSourceDetail")]
    public string? ExternalSourceDetail { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mail")]
    public string? Mail { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("mailingAddress")]
    public PhysicalAddressModel? MailingAddress { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }

    [JsonPropertyName("onPremisesInfo")]
    public EducationOnPremisesInfoModel? OnPremisesInfo { get; set; }

    [JsonPropertyName("passwordPolicies")]
    public string? PasswordPolicies { get; set; }

    [JsonPropertyName("passwordProfile")]
    public PasswordProfileModel? PasswordProfile { get; set; }

    [JsonPropertyName("preferredLanguage")]
    public string? PreferredLanguage { get; set; }

    [JsonPropertyName("primaryRole")]
    public EducationUserPrimaryRoleConstant? PrimaryRole { get; set; }

    [JsonPropertyName("provisionedPlans")]
    public List<ProvisionedPlanModel>? ProvisionedPlans { get; set; }

    [JsonPropertyName("refreshTokensValidFromDateTime")]
    public DateTime? RefreshTokensValidFromDateTime { get; set; }

    [JsonPropertyName("relatedContacts")]
    public List<RelatedContactModel>? RelatedContacts { get; set; }

    [JsonPropertyName("residenceAddress")]
    public PhysicalAddressModel? ResidenceAddress { get; set; }

    [JsonPropertyName("rubrics")]
    public List<EducationRubricModel>? Rubrics { get; set; }

    [JsonPropertyName("schools")]
    public List<EducationSchoolModel>? Schools { get; set; }

    [JsonPropertyName("showInAddressList")]
    public bool? ShowInAddressList { get; set; }

    [JsonPropertyName("student")]
    public EducationStudentModel? Student { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("taughtClasses")]
    public List<EducationClassModel>? TaughtClasses { get; set; }

    [JsonPropertyName("teacher")]
    public EducationTeacherModel? Teacher { get; set; }

    [JsonPropertyName("usageLocation")]
    public string? UsageLocation { get; set; }

    [JsonPropertyName("user")]
    public UserModel? User { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("userType")]
    public string? UserType { get; set; }
}
