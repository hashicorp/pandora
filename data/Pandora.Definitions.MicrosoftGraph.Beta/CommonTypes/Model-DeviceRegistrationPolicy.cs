// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceRegistrationPolicyModel
{
    [JsonPropertyName("azureADJoin")]
    public AzureADJoinPolicyModel? AzureADJoin { get; set; }

    [JsonPropertyName("azureADRegistration")]
    public AzureADRegistrationPolicyModel? AzureADRegistration { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("localAdminPassword")]
    public LocalAdminPasswordSettingsModel? LocalAdminPassword { get; set; }

    [JsonPropertyName("multiFactorAuthConfiguration")]
    public DeviceRegistrationPolicyMultiFactorAuthConfigurationConstant? MultiFactorAuthConfiguration { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userDeviceQuota")]
    public int? UserDeviceQuota { get; set; }
}
