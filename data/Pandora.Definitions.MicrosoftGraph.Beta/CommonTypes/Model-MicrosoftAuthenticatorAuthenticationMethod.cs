// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftAuthenticatorAuthenticationMethodModel
{
    [JsonPropertyName("clientAppName")]
    public MicrosoftAuthenticatorAuthenticationMethodClientAppNameConstant? ClientAppName { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("device")]
    public DeviceModel? Device { get; set; }

    [JsonPropertyName("deviceTag")]
    public string? DeviceTag { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("phoneAppVersion")]
    public string? PhoneAppVersion { get; set; }
}
