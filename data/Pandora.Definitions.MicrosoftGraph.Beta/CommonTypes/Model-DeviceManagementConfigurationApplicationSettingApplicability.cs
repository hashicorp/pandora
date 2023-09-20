// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationApplicationSettingApplicabilityModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceMode")]
    public DeviceManagementConfigurationApplicationSettingApplicabilityDeviceModeConstant? DeviceMode { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public DeviceManagementConfigurationApplicationSettingApplicabilityPlatformConstant? Platform { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementConfigurationApplicationSettingApplicabilityTechnologiesConstant? Technologies { get; set; }
}
