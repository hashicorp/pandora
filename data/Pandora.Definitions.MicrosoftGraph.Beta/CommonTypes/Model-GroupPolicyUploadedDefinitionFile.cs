// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicyUploadedDefinitionFileModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("defaultLanguageCode")]
    public string? DefaultLanguageCode { get; set; }

    [JsonPropertyName("definitions")]
    public List<GroupPolicyDefinitionModel>? Definitions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("groupPolicyOperations")]
    public List<GroupPolicyOperationModel>? GroupPolicyOperations { get; set; }

    [JsonPropertyName("groupPolicyUploadedLanguageFiles")]
    public List<GroupPolicyUploadedLanguageFileModel>? GroupPolicyUploadedLanguageFiles { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("languageCodes")]
    public List<string>? LanguageCodes { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyType")]
    public GroupPolicyUploadedDefinitionFilePolicyTypeConstant? PolicyType { get; set; }

    [JsonPropertyName("revision")]
    public string? Revision { get; set; }

    [JsonPropertyName("status")]
    public GroupPolicyUploadedDefinitionFileStatusConstant? Status { get; set; }

    [JsonPropertyName("targetNamespace")]
    public string? TargetNamespace { get; set; }

    [JsonPropertyName("targetPrefix")]
    public string? TargetPrefix { get; set; }

    [JsonPropertyName("uploadDateTime")]
    public DateTime? UploadDateTime { get; set; }
}
