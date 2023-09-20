// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityRegistryValueEvidenceModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("mdeDeviceId")]
    public string? MdeDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("registryHive")]
    public string? RegistryHive { get; set; }

    [JsonPropertyName("registryKey")]
    public string? RegistryKey { get; set; }

    [JsonPropertyName("registryValue")]
    public string? RegistryValue { get; set; }

    [JsonPropertyName("registryValueName")]
    public string? RegistryValueName { get; set; }

    [JsonPropertyName("registryValueType")]
    public string? RegistryValueType { get; set; }

    [JsonPropertyName("remediationStatus")]
    public SecurityRegistryValueEvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<SecurityRegistryValueEvidenceRolesConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public SecurityRegistryValueEvidenceVerdictConstant? Verdict { get; set; }
}
