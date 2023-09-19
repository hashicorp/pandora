// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementCompliancePolicyModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceManagementConfigurationPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("creationSource")]
    public string? CreationSource { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platforms")]
    public DeviceManagementCompliancePolicyPlatformsConstant? Platforms { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("scheduledActionsForRule")]
    public List<DeviceManagementComplianceScheduledActionForRuleModel>? ScheduledActionsForRule { get; set; }

    [JsonPropertyName("settingCount")]
    public int? SettingCount { get; set; }

    [JsonPropertyName("settings")]
    public List<DeviceManagementConfigurationSettingModel>? Settings { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementCompliancePolicyTechnologiesConstant? Technologies { get; set; }
}
