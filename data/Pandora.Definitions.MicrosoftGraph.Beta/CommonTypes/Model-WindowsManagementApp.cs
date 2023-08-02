// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsManagementAppModel
{
    [JsonPropertyName("availableVersion")]
    public string? AvailableVersion { get; set; }

    [JsonPropertyName("healthStates")]
    public List<WindowsManagementAppHealthStateModel>? HealthStates { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedInstaller")]
    public ManagedInstallerStatusConstant? ManagedInstaller { get; set; }

    [JsonPropertyName("managedInstallerConfiguredDateTime")]
    public string? ManagedInstallerConfiguredDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
