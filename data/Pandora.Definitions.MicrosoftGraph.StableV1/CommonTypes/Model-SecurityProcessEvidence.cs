// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityProcessEvidenceModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("detectionStatus")]
    public DetectionStatusConstant? DetectionStatus { get; set; }

    [JsonPropertyName("imageFile")]
    public FileDetailsModel? ImageFile { get; set; }

    [JsonPropertyName("mdeDeviceId")]
    public string? MdeDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentProcessCreationDateTime")]
    public DateTime? ParentProcessCreationDateTime { get; set; }

    [JsonPropertyName("parentProcessId")]
    public long? ParentProcessId { get; set; }

    [JsonPropertyName("parentProcessImageFile")]
    public FileDetailsModel? ParentProcessImageFile { get; set; }

    [JsonPropertyName("processCommandLine")]
    public string? ProcessCommandLine { get; set; }

    [JsonPropertyName("processCreationDateTime")]
    public DateTime? ProcessCreationDateTime { get; set; }

    [JsonPropertyName("processId")]
    public long? ProcessId { get; set; }

    [JsonPropertyName("remediationStatus")]
    public EvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<EvidenceRoleConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("userAccount")]
    public UserAccountModel? UserAccount { get; set; }

    [JsonPropertyName("verdict")]
    public EvidenceVerdictConstant? Verdict { get; set; }
}
