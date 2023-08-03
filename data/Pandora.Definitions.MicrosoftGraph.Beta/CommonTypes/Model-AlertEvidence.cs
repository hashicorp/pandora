// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AlertEvidenceModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediationStatus")]
    public EvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<EvidenceRoleConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public EvidenceVerdictConstant? Verdict { get; set; }
}
