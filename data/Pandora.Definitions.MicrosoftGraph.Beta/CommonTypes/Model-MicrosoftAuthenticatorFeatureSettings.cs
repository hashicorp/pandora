// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftAuthenticatorFeatureSettingsModel
{
    [JsonPropertyName("companionAppAllowedState")]
    public AuthenticationMethodFeatureConfigurationModel? CompanionAppAllowedState { get; set; }

    [JsonPropertyName("displayAppInformationRequiredState")]
    public AuthenticationMethodFeatureConfigurationModel? DisplayAppInformationRequiredState { get; set; }

    [JsonPropertyName("displayLocationInformationRequiredState")]
    public AuthenticationMethodFeatureConfigurationModel? DisplayLocationInformationRequiredState { get; set; }

    [JsonPropertyName("numberMatchingRequiredState")]
    public AuthenticationMethodFeatureConfigurationModel? NumberMatchingRequiredState { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
