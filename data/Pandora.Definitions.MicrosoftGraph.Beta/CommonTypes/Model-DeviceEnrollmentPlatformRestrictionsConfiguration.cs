// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceEnrollmentPlatformRestrictionsConfigurationModel
{
    [JsonPropertyName("androidForWorkRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? AndroidForWorkRestriction { get; set; }

    [JsonPropertyName("androidRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? AndroidRestriction { get; set; }

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

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("iosRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? IosRestriction { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("macOSRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? MacOSRestriction { get; set; }

    [JsonPropertyName("macRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? MacRestriction { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("windowsHomeSkuRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? WindowsHomeSkuRestriction { get; set; }

    [JsonPropertyName("windowsMobileRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? WindowsMobileRestriction { get; set; }

    [JsonPropertyName("windowsRestriction")]
    public DeviceEnrollmentPlatformRestrictionModel? WindowsRestriction { get; set; }
}
