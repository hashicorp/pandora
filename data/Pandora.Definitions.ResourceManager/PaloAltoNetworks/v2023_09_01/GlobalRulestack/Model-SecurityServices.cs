using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.GlobalRulestack;


internal class SecurityServicesModel
{
    [JsonPropertyName("antiSpywareProfile")]
    public string? AntiSpywareProfile { get; set; }

    [JsonPropertyName("antiVirusProfile")]
    public string? AntiVirusProfile { get; set; }

    [JsonPropertyName("dnsSubscription")]
    public string? DnsSubscription { get; set; }

    [JsonPropertyName("fileBlockingProfile")]
    public string? FileBlockingProfile { get; set; }

    [JsonPropertyName("outboundTrustCertificate")]
    public string? OutboundTrustCertificate { get; set; }

    [JsonPropertyName("outboundUnTrustCertificate")]
    public string? OutboundUnTrustCertificate { get; set; }

    [JsonPropertyName("urlFilteringProfile")]
    public string? UrlFilteringProfile { get; set; }

    [JsonPropertyName("vulnerabilityProfile")]
    public string? VulnerabilityProfile { get; set; }
}
