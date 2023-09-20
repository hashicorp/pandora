// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RestrictedAppsViolationModel
{
    [JsonPropertyName("deviceConfigurationId")]
    public string? DeviceConfigurationId { get; set; }

    [JsonPropertyName("deviceConfigurationName")]
    public string? DeviceConfigurationName { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platformType")]
    public RestrictedAppsViolationPlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("restrictedApps")]
    public List<ManagedDeviceReportedAppModel>? RestrictedApps { get; set; }

    [JsonPropertyName("restrictedAppsState")]
    public RestrictedAppsViolationRestrictedAppsStateConstant? RestrictedAppsState { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
