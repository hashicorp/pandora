// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32LobAppModel
{
    [JsonPropertyName("allowAvailableUninstall")]
    public bool? AllowAvailableUninstall { get; set; }

    [JsonPropertyName("applicableArchitectures")]
    public WindowsArchitectureConstant? ApplicableArchitectures { get; set; }

    [JsonPropertyName("assignments")]
    public List<MobileAppAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("categories")]
    public List<MobileAppCategoryModel>? Categories { get; set; }

    [JsonPropertyName("committedContentVersion")]
    public string? CommittedContentVersion { get; set; }

    [JsonPropertyName("contentVersions")]
    public List<MobileAppContentModel>? ContentVersions { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dependentAppCount")]
    public int? DependentAppCount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detectionRules")]
    public List<Win32LobAppDetectionModel>? DetectionRules { get; set; }

    [JsonPropertyName("developer")]
    public string? Developer { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<MobileAppInstallStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("displayVersion")]
    public string? DisplayVersion { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("informationUrl")]
    public string? InformationUrl { get; set; }

    [JsonPropertyName("installCommandLine")]
    public string? InstallCommandLine { get; set; }

    [JsonPropertyName("installExperience")]
    public Win32LobAppInstallExperienceModel? InstallExperience { get; set; }

    [JsonPropertyName("installSummary")]
    public MobileAppInstallSummaryModel? InstallSummary { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("isFeatured")]
    public bool? IsFeatured { get; set; }

    [JsonPropertyName("largeIcon")]
    public MimeContentModel? LargeIcon { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("minimumCpuSpeedInMHz")]
    public int? MinimumCpuSpeedInMHz { get; set; }

    [JsonPropertyName("minimumFreeDiskSpaceInMB")]
    public int? MinimumFreeDiskSpaceInMB { get; set; }

    [JsonPropertyName("minimumMemoryInMB")]
    public int? MinimumMemoryInMB { get; set; }

    [JsonPropertyName("minimumNumberOfProcessors")]
    public int? MinimumNumberOfProcessors { get; set; }

    [JsonPropertyName("minimumSupportedOperatingSystem")]
    public WindowsMinimumOperatingSystemModel? MinimumSupportedOperatingSystem { get; set; }

    [JsonPropertyName("minimumSupportedWindowsRelease")]
    public string? MinimumSupportedWindowsRelease { get; set; }

    [JsonPropertyName("msiInformation")]
    public Win32LobAppMsiInformationModel? MsiInformation { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("privacyInformationUrl")]
    public string? PrivacyInformationUrl { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("publishingState")]
    public MobileAppPublishingStateConstant? PublishingState { get; set; }

    [JsonPropertyName("relationships")]
    public List<MobileAppRelationshipModel>? Relationships { get; set; }

    [JsonPropertyName("requirementRules")]
    public List<Win32LobAppRequirementModel>? RequirementRules { get; set; }

    [JsonPropertyName("returnCodes")]
    public List<Win32LobAppReturnCodeModel>? ReturnCodes { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("rules")]
    public List<Win32LobAppRuleModel>? Rules { get; set; }

    [JsonPropertyName("setupFilePath")]
    public string? SetupFilePath { get; set; }

    [JsonPropertyName("size")]
    public long? Size { get; set; }

    [JsonPropertyName("supersededAppCount")]
    public int? SupersededAppCount { get; set; }

    [JsonPropertyName("supersedingAppCount")]
    public int? SupersedingAppCount { get; set; }

    [JsonPropertyName("uninstallCommandLine")]
    public string? UninstallCommandLine { get; set; }

    [JsonPropertyName("uploadState")]
    public int? UploadState { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<UserAppInstallStatusModel>? UserStatuses { get; set; }
}
