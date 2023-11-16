// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityHostPortModel
{
    [JsonPropertyName("banners")]
    public List<SecurityHostPortBannerModel>? Banners { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("host")]
    public SecurityHostModel? Host { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastScanDateTime")]
    public DateTime? LastScanDateTime { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("mostRecentSslCertificate")]
    public SecuritySslCertificateModel? MostRecentSslCertificate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("protocol")]
    public SecurityHostPortProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("services")]
    public List<SecurityHostPortComponentModel>? Services { get; set; }

    [JsonPropertyName("status")]
    public SecurityHostPortStatusConstant? Status { get; set; }

    [JsonPropertyName("timesObserved")]
    public int? TimesObserved { get; set; }
}
