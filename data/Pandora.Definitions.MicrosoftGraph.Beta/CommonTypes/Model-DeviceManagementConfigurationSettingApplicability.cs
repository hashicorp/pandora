// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationSettingApplicabilityModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceMode")]
    public DeviceManagementConfigurationSettingApplicabilityDeviceModeConstant? DeviceMode { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public DeviceManagementConfigurationSettingApplicabilityPlatformConstant? Platform { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementConfigurationSettingApplicabilityTechnologiesConstant? Technologies { get; set; }
}
