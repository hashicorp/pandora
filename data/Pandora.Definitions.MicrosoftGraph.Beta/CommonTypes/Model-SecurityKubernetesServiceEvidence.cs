// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityKubernetesServiceEvidenceModel
{
    [JsonPropertyName("clusterIP")]
    public SecurityIpEvidenceModel? ClusterIP { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("externalIPs")]
    public List<SecurityIpEvidenceModel>? ExternalIPs { get; set; }

    [JsonPropertyName("labels")]
    public SecurityDictionaryModel? Labels { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("namespace")]
    public SecurityKubernetesNamespaceEvidenceModel? Namespace { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityKubernetesServiceEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityKubernetesServiceEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("selector")]
    public SecurityDictionaryModel? Selector { get; set; }

    [JsonPropertyName("servicePorts")]
    public List<SecurityKubernetesServicePortModel>? ServicePorts { get; set; }

    [JsonPropertyName("serviceType")]
    public SecurityKubernetesServiceEvidenceServiceTypeConstant? ServiceType { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityKubernetesServiceEvidenceVerdictConstant? Verdict { get; set; }
}
