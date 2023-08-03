// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationWindowsSettingApplicabilityModel
{
    [JsonPropertyName("configurationServiceProviderVersion")]
    public string? ConfigurationServiceProviderVersion { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceMode")]
    public DeviceManagementConfigurationDeviceModeConstant? DeviceMode { get; set; }

    [JsonPropertyName("maximumSupportedVersion")]
    public string? MaximumSupportedVersion { get; set; }

    [JsonPropertyName("minimumSupportedVersion")]
    public string? MinimumSupportedVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public DeviceManagementConfigurationPlatformsConstant? Platform { get; set; }

    [JsonPropertyName("requiredAzureAdTrustType")]
    public DeviceManagementConfigurationAzureAdTrustTypeConstant? RequiredAzureAdTrustType { get; set; }

    [JsonPropertyName("requiresAzureAd")]
    public bool? RequiresAzureAd { get; set; }

    [JsonPropertyName("technologies")]
    public DeviceManagementConfigurationTechnologiesConstant? Technologies { get; set; }

    [JsonPropertyName("windowsSkus")]
    public List<DeviceManagementConfigurationWindowsSkusConstant>? WindowsSkus { get; set; }
}
