// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidManagedStoreAccountEnterpriseSettingsModel
{
    [JsonPropertyName("androidDeviceOwnerFullyManagedEnrollmentEnabled")]
    public bool? AndroidDeviceOwnerFullyManagedEnrollmentEnabled { get; set; }

    [JsonPropertyName("bindStatus")]
    public AndroidManagedStoreAccountEnterpriseSettingsBindStatusConstant? BindStatus { get; set; }

    [JsonPropertyName("companyCodes")]
    public List<AndroidEnrollmentCompanyCodeModel>? CompanyCodes { get; set; }

    [JsonPropertyName("deviceOwnerManagementEnabled")]
    public bool? DeviceOwnerManagementEnabled { get; set; }

    [JsonPropertyName("enrollmentTarget")]
    public AndroidManagedStoreAccountEnterpriseSettingsEnrollmentTargetConstant? EnrollmentTarget { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastAppSyncDateTime")]
    public DateTime? LastAppSyncDateTime { get; set; }

    [JsonPropertyName("lastAppSyncStatus")]
    public AndroidManagedStoreAccountEnterpriseSettingsLastAppSyncStatusConstant? LastAppSyncStatus { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("managedGooglePlayInitialScopeTagIds")]
    public List<string>? ManagedGooglePlayInitialScopeTagIds { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownerOrganizationName")]
    public string? OwnerOrganizationName { get; set; }

    [JsonPropertyName("ownerUserPrincipalName")]
    public string? OwnerUserPrincipalName { get; set; }

    [JsonPropertyName("targetGroupIds")]
    public List<string>? TargetGroupIds { get; set; }
}
