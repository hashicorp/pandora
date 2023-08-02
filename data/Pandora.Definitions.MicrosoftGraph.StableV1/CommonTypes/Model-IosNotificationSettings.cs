// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IosNotificationSettingsModel
{
    [JsonPropertyName("alertType")]
    public IosNotificationAlertTypeConstant? AlertType { get; set; }

    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    [JsonPropertyName("badgesEnabled")]
    public bool? BadgesEnabled { get; set; }

    [JsonPropertyName("bundleID")]
    public string? BundleID { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("showInNotificationCenter")]
    public bool? ShowInNotificationCenter { get; set; }

    [JsonPropertyName("showOnLockScreen")]
    public bool? ShowOnLockScreen { get; set; }

    [JsonPropertyName("soundsEnabled")]
    public bool? SoundsEnabled { get; set; }
}
