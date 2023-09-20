// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharePointIdentitySetModel
{
    [JsonPropertyName("application")]
    public IdentityModel? Application { get; set; }

    [JsonPropertyName("device")]
    public IdentityModel? Device { get; set; }

    [JsonPropertyName("group")]
    public IdentityModel? Group { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("siteGroup")]
    public SharePointIdentityModel? SiteGroup { get; set; }

    [JsonPropertyName("siteUser")]
    public SharePointIdentityModel? SiteUser { get; set; }

    [JsonPropertyName("user")]
    public IdentityModel? User { get; set; }
}
