// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SignInFrequencySessionControlModel
{
    [JsonPropertyName("authenticationType")]
    public SignInFrequencyAuthenticationTypeConstant? AuthenticationType { get; set; }

    [JsonPropertyName("frequencyInterval")]
    public SignInFrequencyIntervalConstant? FrequencyInterval { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("type")]
    public SigninFrequencyTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }
}
