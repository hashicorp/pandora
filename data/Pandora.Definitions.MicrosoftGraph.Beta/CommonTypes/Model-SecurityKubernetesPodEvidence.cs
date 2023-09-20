// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityKubernetesPodEvidenceModel
{
    [JsonPropertyName("containers")]
    public List<SecurityContainerEvidenceModel>? Containers { get; set; }

    [JsonPropertyName("controller")]
    public SecurityKubernetesControllerEvidenceModel? Controller { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("ephemeralContainers")]
    public List<SecurityContainerEvidenceModel>? EphemeralContainers { get; set; }

    [JsonPropertyName("initContainers")]
    public List<SecurityContainerEvidenceModel>? InitContainers { get; set; }

    [JsonPropertyName("labels")]
    public SecurityDictionaryModel? Labels { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("namespace")]
    public SecurityKubernetesNamespaceEvidenceModel? Namespace { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("podIp")]
    public SecurityIpEvidenceModel? PodIp { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityKubernetesPodEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityKubernetesPodEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("serviceAccount")]
    public SecurityKubernetesServiceAccountEvidenceModel? ServiceAccount { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityKubernetesPodEvidenceVerdictConstant? Verdict { get; set; }
}
