// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosSingleSignOnSettingsModel
{
    [JsonPropertyName("allowedAppsList")]
    public List<AppListItemModel>? AllowedAppsList { get; set; }

    [JsonPropertyName("allowedUrls")]
    public List<string>? AllowedUrls { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("kerberosPrincipalName")]
    public string? KerberosPrincipalName { get; set; }

    [JsonPropertyName("kerberosRealm")]
    public string? KerberosRealm { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
