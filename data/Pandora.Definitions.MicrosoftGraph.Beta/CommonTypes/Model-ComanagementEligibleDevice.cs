// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ComanagementEligibleDeviceModel
{
    [JsonPropertyName("clientRegistrationStatus")]
    public ComanagementEligibleDeviceClientRegistrationStatusConstant? ClientRegistrationStatus { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceType")]
    public ComanagementEligibleDeviceDeviceTypeConstant? DeviceType { get; set; }

    [JsonPropertyName("entitySource")]
    public int? EntitySource { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managementAgents")]
    public ComanagementEligibleDeviceManagementAgentsConstant? ManagementAgents { get; set; }

    [JsonPropertyName("managementState")]
    public ComanagementEligibleDeviceManagementStateConstant? ManagementState { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("mdmStatus")]
    public string? MdmStatus { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osDescription")]
    public string? OsDescription { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("ownerType")]
    public ComanagementEligibleDeviceOwnerTypeConstant? OwnerType { get; set; }

    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("status")]
    public ComanagementEligibleDeviceStatusConstant? Status { get; set; }

    [JsonPropertyName("upn")]
    public string? Upn { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
