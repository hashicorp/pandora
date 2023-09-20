// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityBaselineTemplateModel
{
    [JsonPropertyName("categories")]
    public List<DeviceManagementTemplateSettingCategoryModel>? Categories { get; set; }

    [JsonPropertyName("categoryDeviceStateSummaries")]
    public List<SecurityBaselineCategoryStateSummaryModel>? CategoryDeviceStateSummaries { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceStateSummary")]
    public SecurityBaselineStateSummaryModel? DeviceStateSummary { get; set; }

    [JsonPropertyName("deviceStates")]
    public List<SecurityBaselineDeviceStateModel>? DeviceStates { get; set; }

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
    public SecurityBaselineTemplatePlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("publishedDateTime")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("settings")]
    public List<DeviceManagementSettingInstanceModel>? Settings { get; set; }

    [JsonPropertyName("templateSubtype")]
    public SecurityBaselineTemplateTemplateSubtypeConstant? TemplateSubtype { get; set; }

    [JsonPropertyName("templateType")]
    public SecurityBaselineTemplateTemplateTypeConstant? TemplateType { get; set; }

    [JsonPropertyName("versionInfo")]
    public string? VersionInfo { get; set; }
}
