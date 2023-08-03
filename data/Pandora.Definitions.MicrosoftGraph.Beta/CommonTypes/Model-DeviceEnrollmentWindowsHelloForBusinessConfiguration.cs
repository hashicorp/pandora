// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceEnrollmentWindowsHelloForBusinessConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<EnrollmentConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceEnrollmentConfigurationType")]
    public DeviceEnrollmentConfigurationTypeConstant? DeviceEnrollmentConfigurationType { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enhancedBiometricsState")]
    public EnablementConstant? EnhancedBiometricsState { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pinExpirationInDays")]
    public int? PinExpirationInDays { get; set; }

    [JsonPropertyName("pinLowercaseCharactersUsage")]
    public WindowsHelloForBusinessPinUsageConstant? PinLowercaseCharactersUsage { get; set; }

    [JsonPropertyName("pinMaximumLength")]
    public int? PinMaximumLength { get; set; }

    [JsonPropertyName("pinMinimumLength")]
    public int? PinMinimumLength { get; set; }

    [JsonPropertyName("pinPreviousBlockCount")]
    public int? PinPreviousBlockCount { get; set; }

    [JsonPropertyName("pinSpecialCharactersUsage")]
    public WindowsHelloForBusinessPinUsageConstant? PinSpecialCharactersUsage { get; set; }

    [JsonPropertyName("pinUppercaseCharactersUsage")]
    public WindowsHelloForBusinessPinUsageConstant? PinUppercaseCharactersUsage { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("remotePassportEnabled")]
    public bool? RemotePassportEnabled { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("securityDeviceRequired")]
    public bool? SecurityDeviceRequired { get; set; }

    [JsonPropertyName("securityKeyForSignIn")]
    public EnablementConstant? SecurityKeyForSignIn { get; set; }

    [JsonPropertyName("state")]
    public EnablementConstant? State { get; set; }

    [JsonPropertyName("unlockWithBiometricsEnabled")]
    public bool? UnlockWithBiometricsEnabled { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
