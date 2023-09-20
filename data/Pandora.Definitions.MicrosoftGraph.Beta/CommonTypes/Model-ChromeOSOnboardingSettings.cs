// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ChromeOSOnboardingSettingsModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastDirectorySyncDateTime")]
    public DateTime? LastDirectorySyncDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onboardingStatus")]
    public ChromeOSOnboardingSettingsOnboardingStatusConstant? OnboardingStatus { get; set; }

    [JsonPropertyName("ownerUserPrincipalName")]
    public string? OwnerUserPrincipalName { get; set; }
}
