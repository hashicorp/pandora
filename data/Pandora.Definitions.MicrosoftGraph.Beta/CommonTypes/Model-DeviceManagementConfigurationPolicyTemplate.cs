// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationPolicyTemplateModel
{
    [JsonPropertyName("allowUnmanagedSettings")]
    public bool? AllowUnmanagedSettings { get; set; }

    [JsonPropertyName("baseId")]
    public string? BaseId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("displayVersion")]
    public string? DisplayVersion { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lifecycleState")]
    public DeviceManagementConfigurationPolicyTemplateLifecycleStateConstant? LifecycleState { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platforms")]
    public DeviceManagementConfigurationPolicyTemplatePlatformsConstant? Platforms { get; set; }

    [JsonPropertyName("settingTemplateCount")]
    public int? SettingTemplateCount { get; set; }

    [JsonPropertyName("settingTemplates")]
    public List<DeviceManagementConfigurationSettingTemplateModel>? SettingTemplates { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementConfigurationPolicyTemplateTechnologiesConstant? Technologies { get; set; }

    [JsonPropertyName("templateFamily")]
    public DeviceManagementConfigurationPolicyTemplateTemplateFamilyConstant? TemplateFamily { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
