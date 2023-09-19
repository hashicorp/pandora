// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OfficeSuiteAppModel
{
    [JsonPropertyName("assignments")]
    public List<MobileAppAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("autoAcceptEula")]
    public bool? AutoAcceptEula { get; set; }

    [JsonPropertyName("categories")]
    public List<MobileAppCategoryModel>? Categories { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dependentAppCount")]
    public int? DependentAppCount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("developer")]
    public string? Developer { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("excludedApps")]
    public ExcludedAppsModel? ExcludedApps { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("informationUrl")]
    public string? InformationUrl { get; set; }

    [JsonPropertyName("installProgressDisplayLevel")]
    public OfficeSuiteAppInstallProgressDisplayLevelConstant? InstallProgressDisplayLevel { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("isFeatured")]
    public bool? IsFeatured { get; set; }

    [JsonPropertyName("largeIcon")]
    public MimeContentModel? LargeIcon { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("localesToInstall")]
    public List<string>? LocalesToInstall { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeConfigurationXml")]
    public string? OfficeConfigurationXml { get; set; }

    [JsonPropertyName("officePlatformArchitecture")]
    public OfficeSuiteAppOfficePlatformArchitectureConstant? OfficePlatformArchitecture { get; set; }

    [JsonPropertyName("officeSuiteAppDefaultFileFormat")]
    public OfficeSuiteAppOfficeSuiteAppDefaultFileFormatConstant? OfficeSuiteAppDefaultFileFormat { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("privacyInformationUrl")]
    public string? PrivacyInformationUrl { get; set; }

    [JsonPropertyName("productIds")]
    public List<OfficeSuiteAppProductIdsConstant>? ProductIds { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("publishingState")]
    public OfficeSuiteAppPublishingStateConstant? PublishingState { get; set; }

    [JsonPropertyName("relationships")]
    public List<MobileAppRelationshipModel>? Relationships { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("shouldUninstallOlderVersionsOfOffice")]
    public bool? ShouldUninstallOlderVersionsOfOffice { get; set; }

    [JsonPropertyName("supersededAppCount")]
    public int? SupersededAppCount { get; set; }

    [JsonPropertyName("supersedingAppCount")]
    public int? SupersedingAppCount { get; set; }

    [JsonPropertyName("targetVersion")]
    public string? TargetVersion { get; set; }

    [JsonPropertyName("updateChannel")]
    public OfficeSuiteAppUpdateChannelConstant? UpdateChannel { get; set; }

    [JsonPropertyName("updateVersion")]
    public string? UpdateVersion { get; set; }

    [JsonPropertyName("uploadState")]
    public int? UploadState { get; set; }

    [JsonPropertyName("useSharedComputerActivation")]
    public bool? UseSharedComputerActivation { get; set; }
}
