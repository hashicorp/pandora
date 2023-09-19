// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityBlobContainerEvidenceModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityBlobContainerEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityBlobContainerEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("storageResource")]
    public SecurityAzureResourceEvidenceModel? StorageResource { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityBlobContainerEvidenceVerdictConstant? Verdict { get; set; }
}
