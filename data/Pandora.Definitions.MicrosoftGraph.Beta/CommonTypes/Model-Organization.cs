// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OrganizationModel
{
    [JsonPropertyName("assignedPlans")]
    public List<AssignedPlanModel>? AssignedPlans { get; set; }

    [JsonPropertyName("branding")]
    public OrganizationalBrandingModel? Branding { get; set; }

    [JsonPropertyName("businessPhones")]
    public List<string>? BusinessPhones { get; set; }

    [JsonPropertyName("certificateBasedAuthConfiguration")]
    public List<CertificateBasedAuthConfigurationModel>? CertificateBasedAuthConfiguration { get; set; }

    [JsonPropertyName("certificateConnectorSetting")]
    public CertificateConnectorSettingModel? CertificateConnectorSetting { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countryLetterCode")]
    public string? CountryLetterCode { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaultUsageLocation")]
    public string? DefaultUsageLocation { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("directorySizeQuota")]
    public DirectorySizeQuotaModel? DirectorySizeQuota { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isMultipleDataLocationsForServicesEnabled")]
    public bool? IsMultipleDataLocationsForServicesEnabled { get; set; }

    [JsonPropertyName("marketingNotificationEmails")]
    public List<string>? MarketingNotificationEmails { get; set; }

    [JsonPropertyName("mobileDeviceManagementAuthority")]
    public OrganizationMobileDeviceManagementAuthorityConstant? MobileDeviceManagementAuthority { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesLastPasswordSyncDateTime")]
    public DateTime? OnPremisesLastPasswordSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesLastSyncDateTime")]
    public DateTime? OnPremisesLastSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesSyncEnabled")]
    public bool? OnPremisesSyncEnabled { get; set; }

    [JsonPropertyName("partnerInformation")]
    public PartnerInformationModel? PartnerInformation { get; set; }

    [JsonPropertyName("partnerTenantType")]
    public OrganizationPartnerTenantTypeConstant? PartnerTenantType { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("preferredLanguage")]
    public string? PreferredLanguage { get; set; }

    [JsonPropertyName("privacyProfile")]
    public PrivacyProfileModel? PrivacyProfile { get; set; }

    [JsonPropertyName("provisionedPlans")]
    public List<ProvisionedPlanModel>? ProvisionedPlans { get; set; }

    [JsonPropertyName("securityComplianceNotificationMails")]
    public List<string>? SecurityComplianceNotificationMails { get; set; }

    [JsonPropertyName("securityComplianceNotificationPhones")]
    public List<string>? SecurityComplianceNotificationPhones { get; set; }

    [JsonPropertyName("settings")]
    public OrganizationSettingsModel? Settings { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("technicalNotificationMails")]
    public List<string>? TechnicalNotificationMails { get; set; }

    [JsonPropertyName("verifiedDomains")]
    public List<VerifiedDomainModel>? VerifiedDomains { get; set; }
}
