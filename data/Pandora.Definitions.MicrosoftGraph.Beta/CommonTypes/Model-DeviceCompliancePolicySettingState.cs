// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceCompliancePolicySettingStateModel
{
    [JsonPropertyName("currentValue")]
    public string? CurrentValue { get; set; }

    [JsonPropertyName("errorCode")]
    public long? ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string? ErrorDescription { get; set; }

    [JsonPropertyName("instanceDisplayName")]
    public string? InstanceDisplayName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("setting")]
    public string? Setting { get; set; }

    [JsonPropertyName("settingInstanceId")]
    public string? SettingInstanceId { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("sources")]
    public List<SettingSourceModel>? Sources { get; set; }

    [JsonPropertyName("state")]
    public ComplianceStatusConstant? State { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
