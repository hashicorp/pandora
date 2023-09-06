using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class StorageAppliancePropertiesModel
{
    [JsonPropertyName("administratorCredentials")]
    [Required]
    public AdministrativeCredentialsModel AdministratorCredentials { get; set; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("capacityUsed")]
    public int? CapacityUsed { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("detailedStatus")]
    public StorageApplianceDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("managementIpv4Address")]
    public string? ManagementIPv4Address { get; set; }

    [JsonPropertyName("provisioningState")]
    public StorageApplianceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rackId")]
    [Required]
    public string RackId { get; set; }

    [JsonPropertyName("rackSlot")]
    [Required]
    public int RackSlot { get; set; }

    [JsonPropertyName("remoteVendorManagementFeature")]
    public RemoteVendorManagementFeatureConstant? RemoteVendorManagementFeature { get; set; }

    [JsonPropertyName("remoteVendorManagementStatus")]
    public RemoteVendorManagementStatusConstant? RemoteVendorManagementStatus { get; set; }

    [JsonPropertyName("serialNumber")]
    [Required]
    public string SerialNumber { get; set; }

    [JsonPropertyName("storageApplianceSkuId")]
    [Required]
    public string StorageApplianceSkuId { get; set; }
}
