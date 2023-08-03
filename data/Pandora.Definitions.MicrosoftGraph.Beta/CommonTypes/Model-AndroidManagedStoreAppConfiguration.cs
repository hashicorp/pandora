// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidManagedStoreAppConfigurationModel
{
    [JsonPropertyName("appSupportsOemConfig")]
    public bool? AppSupportsOemConfig { get; set; }

    [JsonPropertyName("assignments")]
    public List<ManagedDeviceMobileAppConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("connectedAppsEnabled")]
    public bool? ConnectedAppsEnabled { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceStatusSummary")]
    public ManagedDeviceMobileAppConfigurationDeviceSummaryModel? DeviceStatusSummary { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<ManagedDeviceMobileAppConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("packageId")]
    public string? PackageId { get; set; }

    [JsonPropertyName("payloadJson")]
    public string? PayloadJson { get; set; }

    [JsonPropertyName("permissionActions")]
    public List<AndroidPermissionActionModel>? PermissionActions { get; set; }

    [JsonPropertyName("profileApplicability")]
    public AndroidProfileApplicabilityConstant? ProfileApplicability { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("targetedMobileApps")]
    public List<string>? TargetedMobileApps { get; set; }

    [JsonPropertyName("userStatusSummary")]
    public ManagedDeviceMobileAppConfigurationUserSummaryModel? UserStatusSummary { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<ManagedDeviceMobileAppConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
