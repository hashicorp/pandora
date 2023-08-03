// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicySettingMappingModel
{
    [JsonPropertyName("admxSettingDefinitionId")]
    public string? AdmxSettingDefinitionId { get; set; }

    [JsonPropertyName("childIdList")]
    public List<string>? ChildIdList { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intuneSettingDefinitionId")]
    public string? IntuneSettingDefinitionId { get; set; }

    [JsonPropertyName("intuneSettingUriList")]
    public List<string>? IntuneSettingUriList { get; set; }

    [JsonPropertyName("isMdmSupported")]
    public bool? IsMdmSupported { get; set; }

    [JsonPropertyName("mdmCspName")]
    public string? MdmCspName { get; set; }

    [JsonPropertyName("mdmMinimumOSVersion")]
    public int? MdmMinimumOSVersion { get; set; }

    [JsonPropertyName("mdmSettingUri")]
    public string? MdmSettingUri { get; set; }

    [JsonPropertyName("mdmSupportedState")]
    public MdmSupportedStateConstant? MdmSupportedState { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentId")]
    public string? ParentId { get; set; }

    [JsonPropertyName("settingCategory")]
    public string? SettingCategory { get; set; }

    [JsonPropertyName("settingDisplayName")]
    public string? SettingDisplayName { get; set; }

    [JsonPropertyName("settingDisplayValue")]
    public string? SettingDisplayValue { get; set; }

    [JsonPropertyName("settingDisplayValueType")]
    public string? SettingDisplayValueType { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("settingScope")]
    public GroupPolicySettingScopeConstant? SettingScope { get; set; }

    [JsonPropertyName("settingType")]
    public GroupPolicySettingTypeConstant? SettingType { get; set; }

    [JsonPropertyName("settingValue")]
    public string? SettingValue { get; set; }

    [JsonPropertyName("settingValueDisplayUnits")]
    public string? SettingValueDisplayUnits { get; set; }

    [JsonPropertyName("settingValueType")]
    public string? SettingValueType { get; set; }
}
