// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityProcessEvidenceModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("detectionStatus")]
    public SecurityProcessEvidenceDetectionStatusConstant? DetectionStatus { get; set; }

    [JsonPropertyName("imageFile")]
    public SecurityFileDetailsModel? ImageFile { get; set; }

    [JsonPropertyName("mdeDeviceId")]
    public string? MdeDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentProcessCreationDateTime")]
    public DateTime? ParentProcessCreationDateTime { get; set; }

    [JsonPropertyName("parentProcessId")]
    public int? ParentProcessId { get; set; }

    [JsonPropertyName("parentProcessImageFile")]
    public SecurityFileDetailsModel? ParentProcessImageFile { get; set; }

    [JsonPropertyName("processCommandLine")]
    public string? ProcessCommandLine { get; set; }

    [JsonPropertyName("processCreationDateTime")]
    public DateTime? ProcessCreationDateTime { get; set; }

    [JsonPropertyName("processId")]
    public int? ProcessId { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityProcessEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityProcessEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("userAccount")]
    public SecurityUserAccountModel? UserAccount { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityProcessEvidenceVerdictConstant? Verdict { get; set; }
}
