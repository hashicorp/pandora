// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationIntegerSettingValueTemplateModel
{
    [JsonPropertyName("defaultValue")]
    public DeviceManagementConfigurationIntegerSettingValueDefaultTemplateModel? DefaultValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendedValueDefinition")]
    public DeviceManagementConfigurationIntegerSettingValueDefinitionTemplateModel? RecommendedValueDefinition { get; set; }

    [JsonPropertyName("requiredValueDefinition")]
    public DeviceManagementConfigurationIntegerSettingValueDefinitionTemplateModel? RequiredValueDefinition { get; set; }

    [JsonPropertyName("settingValueTemplateId")]
    public string? SettingValueTemplateId { get; set; }
}
