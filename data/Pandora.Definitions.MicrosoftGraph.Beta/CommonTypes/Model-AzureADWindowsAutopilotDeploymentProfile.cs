// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AzureADWindowsAutopilotDeploymentProfileModel
{
    [JsonPropertyName("assignedDevices")]
    public List<WindowsAutopilotDeviceIdentityModel>? AssignedDevices { get; set; }

    [JsonPropertyName("assignments")]
    public List<WindowsAutopilotDeploymentProfileAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceNameTemplate")]
    public string? DeviceNameTemplate { get; set; }

    [JsonPropertyName("deviceType")]
    public AzureADWindowsAutopilotDeploymentProfileDeviceTypeConstant? DeviceType { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enableWhiteGlove")]
    public bool? EnableWhiteGlove { get; set; }

    [JsonPropertyName("enrollmentStatusScreenSettings")]
    public WindowsEnrollmentStatusScreenSettingsModel? EnrollmentStatusScreenSettings { get; set; }

    [JsonPropertyName("extractHardwareHash")]
    public bool? ExtractHardwareHash { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("managementServiceAppId")]
    public string? ManagementServiceAppId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outOfBoxExperienceSettings")]
    public OutOfBoxExperienceSettingsModel? OutOfBoxExperienceSettings { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }
}
