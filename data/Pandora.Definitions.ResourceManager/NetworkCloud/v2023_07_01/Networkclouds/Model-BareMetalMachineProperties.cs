using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class BareMetalMachinePropertiesModel
{
    [JsonPropertyName("associatedResourceIds")]
    public List<string>? AssociatedResourceIds { get; set; }

    [JsonPropertyName("bmcConnectionString")]
    [Required]
    public string BmcConnectionString { get; set; }

    [JsonPropertyName("bmcCredentials")]
    [Required]
    public AdministrativeCredentialsModel BmcCredentials { get; set; }

    [JsonPropertyName("bmcMacAddress")]
    [Required]
    public string BmcMacAddress { get; set; }

    [JsonPropertyName("bootMacAddress")]
    [Required]
    public string BootMacAddress { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("cordonStatus")]
    public BareMetalMachineCordonStatusConstant? CordonStatus { get; set; }

    [JsonPropertyName("detailedStatus")]
    public BareMetalMachineDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("hardwareInventory")]
    public HardwareInventoryModel? HardwareInventory { get; set; }

    [JsonPropertyName("hardwareValidationStatus")]
    public HardwareValidationStatusModel? HardwareValidationStatus { get; set; }

    [JsonPropertyName("hybridAksClustersAssociatedIds")]
    public List<string>? HybridAksClustersAssociatedIds { get; set; }

    [JsonPropertyName("kubernetesNodeName")]
    public string? KubernetesNodeName { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("machineDetails")]
    [Required]
    public string MachineDetails { get; set; }

    [JsonPropertyName("machineName")]
    [Required]
    public string MachineName { get; set; }

    [JsonPropertyName("machineSkuId")]
    [Required]
    public string MachineSkuId { get; set; }

    [JsonPropertyName("oamIpv4Address")]
    public string? OamIPv4Address { get; set; }

    [JsonPropertyName("oamIpv6Address")]
    public string? OamIPv6Address { get; set; }

    [JsonPropertyName("osImage")]
    public string? OsImage { get; set; }

    [JsonPropertyName("powerState")]
    public BareMetalMachinePowerStateConstant? PowerState { get; set; }

    [JsonPropertyName("provisioningState")]
    public BareMetalMachineProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rackId")]
    [Required]
    public string RackId { get; set; }

    [JsonPropertyName("rackSlot")]
    [Required]
    public int RackSlot { get; set; }

    [JsonPropertyName("readyState")]
    public BareMetalMachineReadyStateConstant? ReadyState { get; set; }

    [JsonPropertyName("serialNumber")]
    [Required]
    public string SerialNumber { get; set; }

    [JsonPropertyName("serviceTag")]
    public string? ServiceTag { get; set; }

    [JsonPropertyName("virtualMachinesAssociatedIds")]
    public List<string>? VirtualMachinesAssociatedIds { get; set; }
}
