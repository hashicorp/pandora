// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkSystemConfigurationModel
{
    [JsonPropertyName("dateTimeConfiguration")]
    public TeamworkDateTimeConfigurationModel? DateTimeConfiguration { get; set; }

    [JsonPropertyName("defaultPassword")]
    public string? DefaultPassword { get; set; }

    [JsonPropertyName("deviceLockTimeout")]
    public string? DeviceLockTimeout { get; set; }

    [JsonPropertyName("isDeviceLockEnabled")]
    public bool? IsDeviceLockEnabled { get; set; }

    [JsonPropertyName("isLoggingEnabled")]
    public bool? IsLoggingEnabled { get; set; }

    [JsonPropertyName("isPowerSavingEnabled")]
    public bool? IsPowerSavingEnabled { get; set; }

    [JsonPropertyName("isScreenCaptureEnabled")]
    public bool? IsScreenCaptureEnabled { get; set; }

    [JsonPropertyName("isSilentModeEnabled")]
    public bool? IsSilentModeEnabled { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("lockPin")]
    public string? LockPin { get; set; }

    [JsonPropertyName("loggingLevel")]
    public string? LoggingLevel { get; set; }

    [JsonPropertyName("networkConfiguration")]
    public TeamworkNetworkConfigurationModel? NetworkConfiguration { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
