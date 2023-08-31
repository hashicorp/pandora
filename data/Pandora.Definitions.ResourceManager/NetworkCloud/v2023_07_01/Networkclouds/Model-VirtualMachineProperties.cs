using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class VirtualMachinePropertiesModel
{
    [JsonPropertyName("adminUsername")]
    [Required]
    public string AdminUsername { get; set; }

    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("bareMetalMachineId")]
    public string? BareMetalMachineId { get; set; }

    [JsonPropertyName("bootMethod")]
    public VirtualMachineBootMethodConstant? BootMethod { get; set; }

    [JsonPropertyName("cloudServicesNetworkAttachment")]
    [Required]
    public NetworkAttachmentModel CloudServicesNetworkAttachment { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("cpuCores")]
    [Required]
    public int CpuCores { get; set; }

    [JsonPropertyName("detailedStatus")]
    public VirtualMachineDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("isolateEmulatorThread")]
    public VirtualMachineIsolateEmulatorThreadConstant? IsolateEmulatorThread { get; set; }

    [JsonPropertyName("memorySizeGB")]
    [Required]
    public int MemorySizeGB { get; set; }

    [JsonPropertyName("networkAttachments")]
    public List<NetworkAttachmentModel>? NetworkAttachments { get; set; }

    [JsonPropertyName("networkData")]
    public string? NetworkData { get; set; }

    [JsonPropertyName("placementHints")]
    public List<VirtualMachinePlacementHintModel>? PlacementHints { get; set; }

    [JsonPropertyName("powerState")]
    public VirtualMachinePowerStateConstant? PowerState { get; set; }

    [JsonPropertyName("provisioningState")]
    public VirtualMachineProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sshPublicKeys")]
    public List<SshPublicKeyModel>? SshPublicKeys { get; set; }

    [JsonPropertyName("storageProfile")]
    [Required]
    public StorageProfileModel StorageProfile { get; set; }

    [JsonPropertyName("userData")]
    public string? UserData { get; set; }

    [JsonPropertyName("vmDeviceModel")]
    public VirtualMachineDeviceModelTypeConstant? VMDeviceModel { get; set; }

    [JsonPropertyName("vmImageRepositoryCredentials")]
    public ImageRepositoryCredentialsModel? VMImageRepositoryCredentials { get; set; }

    [JsonPropertyName("virtioInterface")]
    public VirtualMachineVirtioInterfaceTypeConstant? VirtioInterface { get; set; }

    [JsonPropertyName("vmImage")]
    [Required]
    public string VmImage { get; set; }

    [JsonPropertyName("volumes")]
    public List<string>? Volumes { get; set; }
}
