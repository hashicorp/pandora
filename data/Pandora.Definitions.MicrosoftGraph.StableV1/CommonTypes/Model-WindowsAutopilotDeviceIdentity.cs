// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WindowsAutopilotDeviceIdentityModel
{
    [JsonPropertyName("addressableUserName")]
    public string? AddressableUserName { get; set; }

    [JsonPropertyName("azureActiveDirectoryDeviceId")]
    public string? AzureActiveDirectoryDeviceId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enrollmentState")]
    public WindowsAutopilotDeviceIdentityEnrollmentStateConstant? EnrollmentState { get; set; }

    [JsonPropertyName("groupTag")]
    public string? GroupTag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastContactedDateTime")]
    public DateTime? LastContactedDateTime { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productKey")]
    public string? ProductKey { get; set; }

    [JsonPropertyName("purchaseOrderIdentifier")]
    public string? PurchaseOrderIdentifier { get; set; }

    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("skuNumber")]
    public string? SkuNumber { get; set; }

    [JsonPropertyName("systemFamily")]
    public string? SystemFamily { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
