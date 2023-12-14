// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SignInFrequencySessionControlModel
{
    [JsonPropertyName("authenticationType")]
    public SignInFrequencySessionControlAuthenticationTypeConstant? AuthenticationType { get; set; }

    [JsonPropertyName("frequencyInterval")]
    public SignInFrequencySessionControlFrequencyIntervalConstant? FrequencyInterval { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("type")]
    public SignInFrequencySessionControlTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }
}
