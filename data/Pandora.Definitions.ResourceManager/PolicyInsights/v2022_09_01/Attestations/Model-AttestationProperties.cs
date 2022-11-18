using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2022_09_01.Attestations;


internal class AttestationPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("assessmentDate")]
    public DateTime? AssessmentDate { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("complianceState")]
    public ComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("evidence")]
    public List<AttestationEvidenceModel>? Evidence { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiresOn")]
    public DateTime? ExpiresOn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastComplianceStateChangeAt")]
    public DateTime? LastComplianceStateChangeAt { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("policyAssignmentId")]
    [Required]
    public string PolicyAssignmentId { get; set; }

    [JsonPropertyName("policyDefinitionReferenceId")]
    public string? PolicyDefinitionReferenceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
