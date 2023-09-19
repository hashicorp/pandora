// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityBaselineSettingStateModel
{
    [JsonPropertyName("contributingPolicies")]
    public List<SecurityBaselineContributingPolicyModel>? ContributingPolicies { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settingCategoryId")]
    public string? SettingCategoryId { get; set; }

    [JsonPropertyName("settingCategoryName")]
    public string? SettingCategoryName { get; set; }

    [JsonPropertyName("settingId")]
    public string? SettingId { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("sourcePolicies")]
    public List<SettingSourceModel>? SourcePolicies { get; set; }

    [JsonPropertyName("state")]
    public SecurityBaselineSettingStateStateConstant? State { get; set; }
}
