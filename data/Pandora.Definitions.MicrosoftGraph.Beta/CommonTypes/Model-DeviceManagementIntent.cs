// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementIntentModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceManagementIntentAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("categories")]
    public List<DeviceManagementIntentSettingCategoryModel>? Categories { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<DeviceManagementIntentDeviceSettingStateSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStateSummary")]
    public DeviceManagementIntentDeviceStateSummaryModel? DeviceStateSummary { get; set; }

    [JsonPropertyName("deviceStates")]
    public List<DeviceManagementIntentDeviceStateModel>? DeviceStates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("isMigratingToConfigurationPolicy")]
    public bool? IsMigratingToConfigurationPolicy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("settings")]
    public List<DeviceManagementSettingInstanceModel>? Settings { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }

    [JsonPropertyName("userStateSummary")]
    public DeviceManagementIntentUserStateSummaryModel? UserStateSummary { get; set; }

    [JsonPropertyName("userStates")]
    public List<DeviceManagementIntentUserStateModel>? UserStates { get; set; }
}
