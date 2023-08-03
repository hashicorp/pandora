// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityConfigurationTaskModel
{
    [JsonPropertyName("applicablePlatform")]
    public EndpointSecurityConfigurationApplicablePlatformConstant? ApplicablePlatform { get; set; }

    [JsonPropertyName("assignedTo")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("category")]
    public DeviceAppManagementTaskCategoryConstant? Category { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("creator")]
    public string? Creator { get; set; }

    [JsonPropertyName("creatorNotes")]
    public string? CreatorNotes { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dueDateTime")]
    public DateTime? DueDateTime { get; set; }

    [JsonPropertyName("endpointSecurityPolicy")]
    public EndpointSecurityConfigurationTypeConstant? EndpointSecurityPolicy { get; set; }

    [JsonPropertyName("endpointSecurityPolicyProfile")]
    public EndpointSecurityConfigurationProfileTypeConstant? EndpointSecurityPolicyProfile { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("insights")]
    public string? Insights { get; set; }

    [JsonPropertyName("intendedSettings")]
    public List<KeyValuePairModel>? IntendedSettings { get; set; }

    [JsonPropertyName("managedDeviceCount")]
    public int? ManagedDeviceCount { get; set; }

    [JsonPropertyName("managedDevices")]
    public List<VulnerableManagedDeviceModel>? ManagedDevices { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public DeviceAppManagementTaskPriorityConstant? Priority { get; set; }

    [JsonPropertyName("status")]
    public DeviceAppManagementTaskStatusConstant? Status { get; set; }
}
