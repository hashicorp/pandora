// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedDeviceMobileAppConfigurationStateModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platformType")]
    public ManagedDeviceMobileAppConfigurationStatePlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("settingCount")]
    public int? SettingCount { get; set; }

    [JsonPropertyName("settingStates")]
    public List<ManagedDeviceMobileAppConfigurationSettingStateModel>? SettingStates { get; set; }

    [JsonPropertyName("state")]
    public ManagedDeviceMobileAppConfigurationStateStateConstant? State { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
