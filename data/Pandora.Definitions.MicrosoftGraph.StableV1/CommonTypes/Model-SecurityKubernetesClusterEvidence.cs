// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityKubernetesClusterEvidenceModel
{
    [JsonPropertyName("cloudResource")]
    public SecurityAlertEvidenceModel? CloudResource { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("distribution")]
    public string? Distribution { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public SecurityKubernetesClusterEvidencePlatformConstant? Platform { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityKubernetesClusterEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityKubernetesClusterEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityKubernetesClusterEvidenceVerdictConstant? Verdict { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
