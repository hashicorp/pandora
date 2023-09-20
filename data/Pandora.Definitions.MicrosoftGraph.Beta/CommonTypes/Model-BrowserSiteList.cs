// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BrowserSiteListModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publishedBy")]
    public IdentitySetModel? PublishedBy { get; set; }

    [JsonPropertyName("publishedDateTime")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("revision")]
    public string? Revision { get; set; }

    [JsonPropertyName("sharedCookies")]
    public List<BrowserSharedCookieModel>? SharedCookies { get; set; }

    [JsonPropertyName("sites")]
    public List<BrowserSiteModel>? Sites { get; set; }

    [JsonPropertyName("status")]
    public BrowserSiteListStatusConstant? Status { get; set; }
}
