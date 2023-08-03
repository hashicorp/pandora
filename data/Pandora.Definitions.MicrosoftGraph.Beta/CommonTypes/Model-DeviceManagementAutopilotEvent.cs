// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementAutopilotEventModel
{
    [JsonPropertyName("accountSetupDuration")]
    public string? AccountSetupDuration { get; set; }

    [JsonPropertyName("accountSetupStatus")]
    public WindowsAutopilotDeploymentStateConstant? AccountSetupStatus { get; set; }

    [JsonPropertyName("deploymentDuration")]
    public string? DeploymentDuration { get; set; }

    [JsonPropertyName("deploymentEndDateTime")]
    public DateTime? DeploymentEndDateTime { get; set; }

    [JsonPropertyName("deploymentStartDateTime")]
    public DateTime? DeploymentStartDateTime { get; set; }

    [JsonPropertyName("deploymentState")]
    public WindowsAutopilotDeploymentStateConstant? DeploymentState { get; set; }

    [JsonPropertyName("deploymentTotalDuration")]
    public string? DeploymentTotalDuration { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("devicePreparationDuration")]
    public string? DevicePreparationDuration { get; set; }

    [JsonPropertyName("deviceRegisteredDateTime")]
    public DateTime? DeviceRegisteredDateTime { get; set; }

    [JsonPropertyName("deviceSerialNumber")]
    public string? DeviceSerialNumber { get; set; }

    [JsonPropertyName("deviceSetupDuration")]
    public string? DeviceSetupDuration { get; set; }

    [JsonPropertyName("deviceSetupStatus")]
    public WindowsAutopilotDeploymentStateConstant? DeviceSetupStatus { get; set; }

    [JsonPropertyName("enrollmentFailureDetails")]
    public string? EnrollmentFailureDetails { get; set; }

    [JsonPropertyName("enrollmentStartDateTime")]
    public DateTime? EnrollmentStartDateTime { get; set; }

    [JsonPropertyName("enrollmentState")]
    public EnrollmentStateConstant? EnrollmentState { get; set; }

    [JsonPropertyName("enrollmentType")]
    public WindowsAutopilotEnrollmentTypeConstant? EnrollmentType { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("policyStatusDetails")]
    public List<DeviceManagementAutopilotPolicyStatusDetailModel>? PolicyStatusDetails { get; set; }

    [JsonPropertyName("targetedAppCount")]
    public int? TargetedAppCount { get; set; }

    [JsonPropertyName("targetedPolicyCount")]
    public int? TargetedPolicyCount { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("windows10EnrollmentCompletionPageConfigurationDisplayName")]
    public string? Windows10EnrollmentCompletionPageConfigurationDisplayName { get; set; }

    [JsonPropertyName("windows10EnrollmentCompletionPageConfigurationId")]
    public string? Windows10EnrollmentCompletionPageConfigurationId { get; set; }

    [JsonPropertyName("windowsAutopilotDeploymentProfileDisplayName")]
    public string? WindowsAutopilotDeploymentProfileDisplayName { get; set; }
}
