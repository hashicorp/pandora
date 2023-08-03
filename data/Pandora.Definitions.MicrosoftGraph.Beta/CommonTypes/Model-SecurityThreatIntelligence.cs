// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityThreatIntelligenceModel
{
    [JsonPropertyName("articleIndicators")]
    public List<ArticleIndicatorModel>? ArticleIndicators { get; set; }

    [JsonPropertyName("articles")]
    public List<ArticleModel>? Articles { get; set; }

    [JsonPropertyName("hostComponents")]
    public List<HostComponentModel>? HostComponents { get; set; }

    [JsonPropertyName("hostCookies")]
    public List<HostCookieModel>? HostCookies { get; set; }

    [JsonPropertyName("hostTrackers")]
    public List<HostTrackerModel>? HostTrackers { get; set; }

    [JsonPropertyName("hosts")]
    public List<HostModel>? Hosts { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intelProfiles")]
    public List<IntelligenceProfileModel>? IntelProfiles { get; set; }

    [JsonPropertyName("intelligenceProfileIndicators")]
    public List<IntelligenceProfileIndicatorModel>? IntelligenceProfileIndicators { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveDnsRecords")]
    public List<PassiveDnsRecordModel>? PassiveDnsRecords { get; set; }

    [JsonPropertyName("vulnerabilities")]
    public List<VulnerabilityModel>? Vulnerabilities { get; set; }
}
