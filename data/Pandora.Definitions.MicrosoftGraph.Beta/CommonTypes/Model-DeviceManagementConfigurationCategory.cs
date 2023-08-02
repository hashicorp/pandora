// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationCategoryModel
{
    [JsonPropertyName("categoryDescription")]
    public string? CategoryDescription { get; set; }

    [JsonPropertyName("childCategoryIds")]
    public List<string>? ChildCategoryIds { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("helpText")]
    public string? HelpText { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentCategoryId")]
    public string? ParentCategoryId { get; set; }

    [JsonPropertyName("platforms")]
    public DeviceManagementConfigurationPlatformsConstant? Platforms { get; set; }

    [JsonPropertyName("rootCategoryId")]
    public string? RootCategoryId { get; set; }

    [JsonPropertyName("settingUsage")]
    public DeviceManagementConfigurationSettingUsageConstant? SettingUsage { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementConfigurationTechnologiesConstant? Technologies { get; set; }
}
