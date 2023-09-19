// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10EnrollmentCompletionPageConfigurationModel
{
    [JsonPropertyName("allowDeviceResetOnInstallFailure")]
    public bool? AllowDeviceResetOnInstallFailure { get; set; }

    [JsonPropertyName("allowDeviceUseOnInstallFailure")]
    public bool? AllowDeviceUseOnInstallFailure { get; set; }

    [JsonPropertyName("allowLogCollectionOnInstallFailure")]
    public bool? AllowLogCollectionOnInstallFailure { get; set; }

    [JsonPropertyName("allowNonBlockingAppInstallation")]
    public bool? AllowNonBlockingAppInstallation { get; set; }

    [JsonPropertyName("assignments")]
    public List<EnrollmentConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("blockDeviceSetupRetryByUser")]
    public bool? BlockDeviceSetupRetryByUser { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customErrorMessage")]
    public string? CustomErrorMessage { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceEnrollmentConfigurationType")]
    public Windows10EnrollmentCompletionPageConfigurationDeviceEnrollmentConfigurationTypeConstant? DeviceEnrollmentConfigurationType { get; set; }

    [JsonPropertyName("disableUserStatusTrackingAfterFirstUser")]
    public bool? DisableUserStatusTrackingAfterFirstUser { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("installProgressTimeoutInMinutes")]
    public int? InstallProgressTimeoutInMinutes { get; set; }

    [JsonPropertyName("installQualityUpdates")]
    public bool? InstallQualityUpdates { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("selectedMobileAppIds")]
    public List<string>? SelectedMobileAppIds { get; set; }

    [JsonPropertyName("showInstallationProgress")]
    public bool? ShowInstallationProgress { get; set; }

    [JsonPropertyName("trackInstallProgressForAutopilotOnly")]
    public bool? TrackInstallProgressForAutopilotOnly { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
