// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AuthenticationModel
{
    [JsonPropertyName("emailMethods")]
    public List<EmailAuthenticationMethodModel>? EmailMethods { get; set; }

    [JsonPropertyName("fido2Methods")]
    public List<Fido2AuthenticationMethodModel>? Fido2Methods { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("methods")]
    public List<AuthenticationMethodModel>? Methods { get; set; }

    [JsonPropertyName("microsoftAuthenticatorMethods")]
    public List<MicrosoftAuthenticatorAuthenticationMethodModel>? MicrosoftAuthenticatorMethods { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<LongRunningOperationModel>? Operations { get; set; }

    [JsonPropertyName("passwordMethods")]
    public List<PasswordAuthenticationMethodModel>? PasswordMethods { get; set; }

    [JsonPropertyName("phoneMethods")]
    public List<PhoneAuthenticationMethodModel>? PhoneMethods { get; set; }

    [JsonPropertyName("softwareOathMethods")]
    public List<SoftwareOathAuthenticationMethodModel>? SoftwareOathMethods { get; set; }

    [JsonPropertyName("temporaryAccessPassMethods")]
    public List<TemporaryAccessPassAuthenticationMethodModel>? TemporaryAccessPassMethods { get; set; }

    [JsonPropertyName("windowsHelloForBusinessMethods")]
    public List<WindowsHelloForBusinessAuthenticationMethodModel>? WindowsHelloForBusinessMethods { get; set; }
}
