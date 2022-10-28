using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.ManagedClusters;


internal class ManagedClusterAgentPoolProfileModel
{
    [JsonPropertyName("availabilityZones")]
    public CustomTypes.Zones? AvailabilityZones { get; set; }

    [JsonPropertyName("capacityReservationGroupID")]
    public string? CapacityReservationGroupID { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("creationData")]
    public CreationDataModel? CreationData { get; set; }

    [JsonPropertyName("currentOrchestratorVersion")]
    public string? CurrentOrchestratorVersion { get; set; }

    [JsonPropertyName("enableAutoScaling")]
    public bool? EnableAutoScaling { get; set; }

    [JsonPropertyName("enableCustomCATrust")]
    public bool? EnableCustomCATrust { get; set; }

    [JsonPropertyName("enableEncryptionAtHost")]
    public bool? EnableEncryptionAtHost { get; set; }

    [JsonPropertyName("enableFIPS")]
    public bool? EnableFIPS { get; set; }

    [JsonPropertyName("enableNodePublicIP")]
    public bool? EnableNodePublicIP { get; set; }

    [JsonPropertyName("enableUltraSSD")]
    public bool? EnableUltraSSD { get; set; }

    [JsonPropertyName("gpuInstanceProfile")]
    public GPUInstanceProfileConstant? GpuInstanceProfile { get; set; }

    [JsonPropertyName("hostGroupID")]
    public string? HostGroupID { get; set; }

    [JsonPropertyName("kubeletConfig")]
    public KubeletConfigModel? KubeletConfig { get; set; }

    [JsonPropertyName("kubeletDiskType")]
    public KubeletDiskTypeConstant? KubeletDiskType { get; set; }

    [JsonPropertyName("linuxOSConfig")]
    public LinuxOSConfigModel? LinuxOSConfig { get; set; }

    [JsonPropertyName("maxCount")]
    public int? MaxCount { get; set; }

    [JsonPropertyName("maxPods")]
    public int? MaxPods { get; set; }

    [JsonPropertyName("messageOfTheDay")]
    public string? MessageOfTheDay { get; set; }

    [JsonPropertyName("minCount")]
    public int? MinCount { get; set; }

    [JsonPropertyName("mode")]
    public AgentPoolModeConstant? Mode { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("nodeImageVersion")]
    public string? NodeImageVersion { get; set; }

    [JsonPropertyName("nodeLabels")]
    public Dictionary<string, string>? NodeLabels { get; set; }

    [JsonPropertyName("nodePublicIPPrefixID")]
    public string? NodePublicIPPrefixID { get; set; }

    [JsonPropertyName("nodeTaints")]
    public List<string>? NodeTaints { get; set; }

    [JsonPropertyName("orchestratorVersion")]
    public string? OrchestratorVersion { get; set; }

    [JsonPropertyName("osDiskSizeGB")]
    public int? OsDiskSizeGB { get; set; }

    [JsonPropertyName("osDiskType")]
    public OSDiskTypeConstant? OsDiskType { get; set; }

    [JsonPropertyName("osSKU")]
    public OSSKUConstant? OsSKU { get; set; }

    [JsonPropertyName("osType")]
    public OSTypeConstant? OsType { get; set; }

    [JsonPropertyName("podSubnetID")]
    public string? PodSubnetID { get; set; }

    [JsonPropertyName("powerState")]
    public PowerStateModel? PowerState { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("proximityPlacementGroupID")]
    public string? ProximityPlacementGroupID { get; set; }

    [JsonPropertyName("scaleDownMode")]
    public ScaleDownModeConstant? ScaleDownMode { get; set; }

    [JsonPropertyName("scaleSetEvictionPolicy")]
    public ScaleSetEvictionPolicyConstant? ScaleSetEvictionPolicy { get; set; }

    [JsonPropertyName("scaleSetPriority")]
    public ScaleSetPriorityConstant? ScaleSetPriority { get; set; }

    [JsonPropertyName("spotMaxPrice")]
    public float? SpotMaxPrice { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("type")]
    public AgentPoolTypeConstant? Type { get; set; }

    [JsonPropertyName("upgradeSettings")]
    public AgentPoolUpgradeSettingsModel? UpgradeSettings { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }

    [JsonPropertyName("vnetSubnetID")]
    public string? VnetSubnetID { get; set; }

    [JsonPropertyName("windowsProfile")]
    public AgentPoolWindowsProfileModel? WindowsProfile { get; set; }

    [JsonPropertyName("workloadRuntime")]
    public WorkloadRuntimeConstant? WorkloadRuntime { get; set; }
}
