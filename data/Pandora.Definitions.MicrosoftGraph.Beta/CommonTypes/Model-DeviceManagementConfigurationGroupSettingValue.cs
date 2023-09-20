// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationGroupSettingValueModel
{
    [JsonPropertyName("children")]
    public List<DeviceManagementConfigurationSettingInstanceModel>? Children { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settingValueTemplateReference")]
    public DeviceManagementConfigurationSettingValueTemplateReferenceModel? SettingValueTemplateReference { get; set; }
}
