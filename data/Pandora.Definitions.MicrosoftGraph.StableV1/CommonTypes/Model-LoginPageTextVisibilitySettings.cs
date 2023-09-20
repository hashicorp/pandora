// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LoginPageTextVisibilitySettingsModel
{
    [JsonPropertyName("hideAccountResetCredentials")]
    public bool? HideAccountResetCredentials { get; set; }

    [JsonPropertyName("hideCannotAccessYourAccount")]
    public bool? HideCannotAccessYourAccount { get; set; }

    [JsonPropertyName("hideForgotMyPassword")]
    public bool? HideForgotMyPassword { get; set; }

    [JsonPropertyName("hidePrivacyAndCookies")]
    public bool? HidePrivacyAndCookies { get; set; }

    [JsonPropertyName("hideResetItNow")]
    public bool? HideResetItNow { get; set; }

    [JsonPropertyName("hideTermsOfUse")]
    public bool? HideTermsOfUse { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
