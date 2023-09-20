// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationSettingDefinitionModel
{
    [JsonPropertyName("accessTypes")]
    public DeviceManagementConfigurationSettingDefinitionAccessTypesConstant? AccessTypes { get; set; }

    [JsonPropertyName("applicability")]
    public DeviceManagementConfigurationSettingApplicabilityModel? Applicability { get; set; }

    [JsonPropertyName("baseUri")]
    public string? BaseUri { get; set; }

    [JsonPropertyName("categoryId")]
    public string? CategoryId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("helpText")]
    public string? HelpText { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("infoUrls")]
    public List<string>? InfoUrls { get; set; }

    [JsonPropertyName("keywords")]
    public List<string>? Keywords { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("occurrence")]
    public DeviceManagementConfigurationSettingOccurrenceModel? Occurrence { get; set; }

    [JsonPropertyName("offsetUri")]
    public string? OffsetUri { get; set; }

    [JsonPropertyName("referredSettingInformationList")]
    public List<DeviceManagementConfigurationReferredSettingInformationModel>? ReferredSettingInformationList { get; set; }

    [JsonPropertyName("rootDefinitionId")]
    public string? RootDefinitionId { get; set; }

    [JsonPropertyName("settingUsage")]
    public DeviceManagementConfigurationSettingDefinitionSettingUsageConstant? SettingUsage { get; set; }

    [JsonPropertyName("uxBehavior")]
    public DeviceManagementConfigurationSettingDefinitionUxBehaviorConstant? UxBehavior { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("visibility")]
    public DeviceManagementConfigurationSettingDefinitionVisibilityConstant? Visibility { get; set; }
}
