// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityThreatIntelligenceModel
{
    [JsonPropertyName("articleIndicators")]
    public List<SecurityArticleIndicatorModel>? ArticleIndicators { get; set; }

    [JsonPropertyName("articles")]
    public List<SecurityArticleModel>? Articles { get; set; }

    [JsonPropertyName("hostComponents")]
    public List<SecurityHostComponentModel>? HostComponents { get; set; }

    [JsonPropertyName("hostCookies")]
    public List<SecurityHostCookieModel>? HostCookies { get; set; }

    [JsonPropertyName("hostPairs")]
    public List<SecurityHostPairModel>? HostPairs { get; set; }

    [JsonPropertyName("hostPorts")]
    public List<SecurityHostPortModel>? HostPorts { get; set; }

    [JsonPropertyName("hostSslCertificates")]
    public List<SecurityHostSslCertificateModel>? HostSslCertificates { get; set; }

    [JsonPropertyName("hostTrackers")]
    public List<SecurityHostTrackerModel>? HostTrackers { get; set; }

    [JsonPropertyName("hosts")]
    public List<SecurityHostModel>? Hosts { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intelProfiles")]
    public List<SecurityIntelligenceProfileModel>? IntelProfiles { get; set; }

    [JsonPropertyName("intelligenceProfileIndicators")]
    public List<SecurityIntelligenceProfileIndicatorModel>? IntelligenceProfileIndicators { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveDnsRecords")]
    public List<SecurityPassiveDnsRecordModel>? PassiveDnsRecords { get; set; }

    [JsonPropertyName("sslCertificates")]
    public List<SecuritySslCertificateModel>? SslCertificates { get; set; }

    [JsonPropertyName("subdomains")]
    public List<SecuritySubdomainModel>? Subdomains { get; set; }

    [JsonPropertyName("vulnerabilities")]
    public List<SecurityVulnerabilityModel>? Vulnerabilities { get; set; }

    [JsonPropertyName("whoisHistoryRecords")]
    public List<SecurityWhoisHistoryRecordModel>? WhoisHistoryRecords { get; set; }

    [JsonPropertyName("whoisRecords")]
    public List<SecurityWhoisRecordModel>? WhoisRecords { get; set; }
}
