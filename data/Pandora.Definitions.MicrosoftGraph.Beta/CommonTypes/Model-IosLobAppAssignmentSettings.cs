// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosLobAppAssignmentSettingsModel
{
    [JsonPropertyName("isRemovable")]
    public bool? IsRemovable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("preventManagedAppBackup")]
    public bool? PreventManagedAppBackup { get; set; }

    [JsonPropertyName("uninstallOnDeviceRemoval")]
    public bool? UninstallOnDeviceRemoval { get; set; }

    [JsonPropertyName("vpnConfigurationId")]
    public string? VpnConfigurationId { get; set; }
}
