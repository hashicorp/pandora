// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedDeviceEncryptionStateModel
{
    [JsonPropertyName("advancedBitLockerStates")]
    public AdvancedBitLockerStateConstant? AdvancedBitLockerStates { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceType")]
    public DeviceTypesConstant? DeviceType { get; set; }

    [JsonPropertyName("encryptionPolicySettingState")]
    public ComplianceStatusConstant? EncryptionPolicySettingState { get; set; }

    [JsonPropertyName("encryptionReadinessState")]
    public EncryptionReadinessStateConstant? EncryptionReadinessState { get; set; }

    [JsonPropertyName("encryptionState")]
    public EncryptionStateConstant? EncryptionState { get; set; }

    [JsonPropertyName("fileVaultStates")]
    public FileVaultStateConstant? FileVaultStates { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("policyDetails")]
    public List<EncryptionReportPolicyDetailsModel>? PolicyDetails { get; set; }

    [JsonPropertyName("tpmSpecificationVersion")]
    public string? TpmSpecificationVersion { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
