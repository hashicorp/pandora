// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationSimpleSettingCollectionInstanceTemplateModel
{
    [JsonPropertyName("allowUnmanagedValues")]
    public bool? AllowUnmanagedValues { get; set; }

    [JsonPropertyName("isRequired")]
    public bool? IsRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settingDefinitionId")]
    public string? SettingDefinitionId { get; set; }

    [JsonPropertyName("settingInstanceTemplateId")]
    public string? SettingInstanceTemplateId { get; set; }

    [JsonPropertyName("simpleSettingCollectionValueTemplate")]
    public List<DeviceManagementConfigurationSimpleSettingValueTemplateModel>? SimpleSettingCollectionValueTemplate { get; set; }
}
