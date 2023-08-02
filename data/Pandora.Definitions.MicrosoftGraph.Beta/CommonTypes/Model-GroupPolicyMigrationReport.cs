// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicyMigrationReportModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("groupPolicyCreatedDateTime")]
    public DateTime? GroupPolicyCreatedDateTime { get; set; }

    [JsonPropertyName("groupPolicyLastModifiedDateTime")]
    public DateTime? GroupPolicyLastModifiedDateTime { get; set; }

    [JsonPropertyName("groupPolicyObjectId")]
    public string? GroupPolicyObjectId { get; set; }

    [JsonPropertyName("groupPolicySettingMappings")]
    public List<GroupPolicySettingMappingModel>? GroupPolicySettingMappings { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("migrationReadiness")]
    public GroupPolicyMigrationReadinessConstant? MigrationReadiness { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ouDistinguishedName")]
    public string? OuDistinguishedName { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("supportedSettingsCount")]
    public int? SupportedSettingsCount { get; set; }

    [JsonPropertyName("supportedSettingsPercent")]
    public int? SupportedSettingsPercent { get; set; }

    [JsonPropertyName("targetedInActiveDirectory")]
    public bool? TargetedInActiveDirectory { get; set; }

    [JsonPropertyName("totalSettingsCount")]
    public int? TotalSettingsCount { get; set; }

    [JsonPropertyName("unsupportedGroupPolicyExtensions")]
    public List<UnsupportedGroupPolicyExtensionModel>? UnsupportedGroupPolicyExtensions { get; set; }
}
