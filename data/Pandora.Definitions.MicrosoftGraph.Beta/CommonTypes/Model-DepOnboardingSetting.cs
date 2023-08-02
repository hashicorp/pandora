// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DepOnboardingSettingModel
{
    [JsonPropertyName("appleIdentifier")]
    public string? AppleIdentifier { get; set; }

    [JsonPropertyName("dataSharingConsentGranted")]
    public bool? DataSharingConsentGranted { get; set; }

    [JsonPropertyName("defaultIosEnrollmentProfile")]
    public DepIOSEnrollmentProfileModel? DefaultIosEnrollmentProfile { get; set; }

    [JsonPropertyName("defaultMacOsEnrollmentProfile")]
    public DepMacOSEnrollmentProfileModel? DefaultMacOsEnrollmentProfile { get; set; }

    [JsonPropertyName("enrollmentProfiles")]
    public List<EnrollmentProfileModel>? EnrollmentProfiles { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importedAppleDeviceIdentities")]
    public List<ImportedAppleDeviceIdentityModel>? ImportedAppleDeviceIdentities { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastSuccessfulSyncDateTime")]
    public DateTime? LastSuccessfulSyncDateTime { get; set; }

    [JsonPropertyName("lastSyncErrorCode")]
    public int? LastSyncErrorCode { get; set; }

    [JsonPropertyName("lastSyncTriggeredDateTime")]
    public DateTime? LastSyncTriggeredDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("shareTokenWithSchoolDataSyncService")]
    public bool? ShareTokenWithSchoolDataSyncService { get; set; }

    [JsonPropertyName("syncedDeviceCount")]
    public int? SyncedDeviceCount { get; set; }

    [JsonPropertyName("tokenExpirationDateTime")]
    public DateTime? TokenExpirationDateTime { get; set; }

    [JsonPropertyName("tokenName")]
    public string? TokenName { get; set; }

    [JsonPropertyName("tokenType")]
    public DepTokenTypeConstant? TokenType { get; set; }
}
