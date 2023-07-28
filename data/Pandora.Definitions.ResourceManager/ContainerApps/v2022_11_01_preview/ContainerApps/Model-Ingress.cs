using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerApps;


internal class IngressModel
{
    [JsonPropertyName("allowInsecure")]
    public bool? AllowInsecure { get; set; }

    [JsonPropertyName("clientCertificateMode")]
    public IngressClientCertificateModeConstant? ClientCertificateMode { get; set; }

    [JsonPropertyName("corsPolicy")]
    public CorsPolicyModel? CorsPolicy { get; set; }

    [JsonPropertyName("customDomains")]
    public List<CustomDomainModel>? CustomDomains { get; set; }

    [JsonPropertyName("exposedPort")]
    public int? ExposedPort { get; set; }

    [JsonPropertyName("external")]
    public bool? External { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("ipSecurityRestrictions")]
    public List<IPSecurityRestrictionRuleModel>? IPSecurityRestrictions { get; set; }

    [JsonPropertyName("stickySessions")]
    public IngressStickySessionsModel? StickySessions { get; set; }

    [JsonPropertyName("targetPort")]
    public int? TargetPort { get; set; }

    [JsonPropertyName("traffic")]
    public List<TrafficWeightModel>? Traffic { get; set; }

    [JsonPropertyName("transport")]
    public IngressTransportMethodConstant? Transport { get; set; }
}
