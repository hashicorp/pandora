// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicyDefinitionModel
{
    [JsonPropertyName("category")]
    public GroupPolicyCategoryModel? Category { get; set; }

    [JsonPropertyName("categoryPath")]
    public string? CategoryPath { get; set; }

    [JsonPropertyName("classType")]
    public GroupPolicyDefinitionClassTypeConstant? ClassType { get; set; }

    [JsonPropertyName("definitionFile")]
    public GroupPolicyDefinitionFileModel? DefinitionFile { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("explainText")]
    public string? ExplainText { get; set; }

    [JsonPropertyName("groupPolicyCategoryId")]
    public string? GroupPolicyCategoryId { get; set; }

    [JsonPropertyName("hasRelatedDefinitions")]
    public bool? HasRelatedDefinitions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("minDeviceCspVersion")]
    public string? MinDeviceCspVersion { get; set; }

    [JsonPropertyName("minUserCspVersion")]
    public string? MinUserCspVersion { get; set; }

    [JsonPropertyName("nextVersionDefinition")]
    public GroupPolicyDefinitionModel? NextVersionDefinition { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyType")]
    public GroupPolicyTypeConstant? PolicyType { get; set; }

    [JsonPropertyName("presentations")]
    public List<GroupPolicyPresentationModel>? Presentations { get; set; }

    [JsonPropertyName("previousVersionDefinition")]
    public GroupPolicyDefinitionModel? PreviousVersionDefinition { get; set; }

    [JsonPropertyName("supportedOn")]
    public string? SupportedOn { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
