// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsPackageInformationModel
{
    [JsonPropertyName("applicableArchitecture")]
    public WindowsArchitectureConstant? ApplicableArchitecture { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("identityName")]
    public string? IdentityName { get; set; }

    [JsonPropertyName("identityPublisher")]
    public string? IdentityPublisher { get; set; }

    [JsonPropertyName("identityResourceIdentifier")]
    public string? IdentityResourceIdentifier { get; set; }

    [JsonPropertyName("identityVersion")]
    public string? IdentityVersion { get; set; }

    [JsonPropertyName("minimumSupportedOperatingSystem")]
    public WindowsMinimumOperatingSystemModel? MinimumSupportedOperatingSystem { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
