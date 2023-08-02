// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessSessionControlsModel
{
    [JsonPropertyName("applicationEnforcedRestrictions")]
    public ApplicationEnforcedRestrictionsSessionControlModel? ApplicationEnforcedRestrictions { get; set; }

    [JsonPropertyName("cloudAppSecurity")]
    public CloudAppSecuritySessionControlModel? CloudAppSecurity { get; set; }

    [JsonPropertyName("disableResilienceDefaults")]
    public bool? DisableResilienceDefaults { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("persistentBrowser")]
    public PersistentBrowserSessionControlModel? PersistentBrowser { get; set; }

    [JsonPropertyName("signInFrequency")]
    public SignInFrequencySessionControlModel? SignInFrequency { get; set; }
}
