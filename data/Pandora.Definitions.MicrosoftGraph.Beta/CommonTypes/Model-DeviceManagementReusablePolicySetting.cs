// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementReusablePolicySettingModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("referencingConfigurationPolicies")]
    public List<DeviceManagementConfigurationPolicyModel>? ReferencingConfigurationPolicies { get; set; }

    [JsonPropertyName("referencingConfigurationPolicyCount")]
    public int? ReferencingConfigurationPolicyCount { get; set; }

    [JsonPropertyName("settingDefinitionId")]
    public string? SettingDefinitionId { get; set; }

    [JsonPropertyName("settingInstance")]
    public DeviceManagementConfigurationSettingInstanceModel? SettingInstance { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
