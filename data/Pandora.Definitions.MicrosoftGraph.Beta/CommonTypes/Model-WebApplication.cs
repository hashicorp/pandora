// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WebApplicationModel
{
    [JsonPropertyName("homePageUrl")]
    public string? HomePageUrl { get; set; }

    [JsonPropertyName("implicitGrantSettings")]
    public ImplicitGrantSettingsModel? ImplicitGrantSettings { get; set; }

    [JsonPropertyName("logoutUrl")]
    public string? LogoutUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oauth2AllowImplicitFlow")]
    public bool? Oauth2AllowImplicitFlow { get; set; }

    [JsonPropertyName("redirectUriSettings")]
    public List<RedirectUriSettingsModel>? RedirectUriSettings { get; set; }

    [JsonPropertyName("redirectUris")]
    public List<string>? RedirectUris { get; set; }
}
