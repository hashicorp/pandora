// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementTemplateModel
{
    [JsonPropertyName("categories")]
    public List<DeviceManagementTemplateSettingCategoryModel>? Categories { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intentCount")]
    public int? IntentCount { get; set; }

    [JsonPropertyName("isDeprecated")]
    public bool? IsDeprecated { get; set; }

    [JsonPropertyName("migratableTo")]
    public List<DeviceManagementTemplateModel>? MigratableTo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platformType")]
    public DeviceManagementTemplatePlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("publishedDateTime")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("settings")]
    public List<DeviceManagementSettingInstanceModel>? Settings { get; set; }

    [JsonPropertyName("templateSubtype")]
    public DeviceManagementTemplateTemplateSubtypeConstant? TemplateSubtype { get; set; }

    [JsonPropertyName("templateType")]
    public DeviceManagementTemplateTemplateTypeConstant? TemplateType { get; set; }

    [JsonPropertyName("versionInfo")]
    public string? VersionInfo { get; set; }
}
