// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsEnrollmentStatusScreenSettingsModel
{
    [JsonPropertyName("allowDeviceUseBeforeProfileAndAppInstallComplete")]
    public bool? AllowDeviceUseBeforeProfileAndAppInstallComplete { get; set; }

    [JsonPropertyName("allowDeviceUseOnInstallFailure")]
    public bool? AllowDeviceUseOnInstallFailure { get; set; }

    [JsonPropertyName("allowLogCollectionOnInstallFailure")]
    public bool? AllowLogCollectionOnInstallFailure { get; set; }

    [JsonPropertyName("blockDeviceSetupRetryByUser")]
    public bool? BlockDeviceSetupRetryByUser { get; set; }

    [JsonPropertyName("customErrorMessage")]
    public string? CustomErrorMessage { get; set; }

    [JsonPropertyName("hideInstallationProgress")]
    public bool? HideInstallationProgress { get; set; }

    [JsonPropertyName("installProgressTimeoutInMinutes")]
    public int? InstallProgressTimeoutInMinutes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
