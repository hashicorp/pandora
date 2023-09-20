// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ManagedAppRegistrationModel
{
    [JsonPropertyName("appIdentifier")]
    public MobileAppIdentifierModel? AppIdentifier { get; set; }

    [JsonPropertyName("applicationVersion")]
    public string? ApplicationVersion { get; set; }

    [JsonPropertyName("appliedPolicies")]
    public List<ManagedAppPolicyModel>? AppliedPolicies { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceTag")]
    public string? DeviceTag { get; set; }

    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    [JsonPropertyName("flaggedReasons")]
    public List<ManagedAppRegistrationFlaggedReasonsConstant>? FlaggedReasons { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intendedPolicies")]
    public List<ManagedAppPolicyModel>? IntendedPolicies { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("managementSdkVersion")]
    public string? ManagementSdkVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<ManagedAppOperationModel>? Operations { get; set; }

    [JsonPropertyName("platformVersion")]
    public string? PlatformVersion { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
