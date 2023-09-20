// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OutOfBoxExperienceSettingsModel
{
    [JsonPropertyName("deviceUsageType")]
    public OutOfBoxExperienceSettingsDeviceUsageTypeConstant? DeviceUsageType { get; set; }

    [JsonPropertyName("hideEULA")]
    public bool? HideEULA { get; set; }

    [JsonPropertyName("hideEscapeLink")]
    public bool? HideEscapeLink { get; set; }

    [JsonPropertyName("hidePrivacySettings")]
    public bool? HidePrivacySettings { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("skipKeyboardSelectionPage")]
    public bool? SkipKeyboardSelectionPage { get; set; }

    [JsonPropertyName("userType")]
    public OutOfBoxExperienceSettingsUserTypeConstant? UserType { get; set; }
}
