using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineScaleSetVMInstanceViewModel
{
    [JsonPropertyName("assignedHost")]
    public string? AssignedHost { get; set; }

    [JsonPropertyName("bootDiagnostics")]
    public BootDiagnosticsInstanceViewModel? BootDiagnostics { get; set; }

    [JsonPropertyName("disks")]
    public List<DiskInstanceViewModel>? Disks { get; set; }

    [JsonPropertyName("extensions")]
    public List<VirtualMachineExtensionInstanceViewModel>? Extensions { get; set; }

    [JsonPropertyName("maintenanceRedeployStatus")]
    public MaintenanceRedeployStatusModel? MaintenanceRedeployStatus { get; set; }

    [JsonPropertyName("placementGroupId")]
    public string? PlacementGroupId { get; set; }

    [JsonPropertyName("platformFaultDomain")]
    public int? PlatformFaultDomain { get; set; }

    [JsonPropertyName("platformUpdateDomain")]
    public int? PlatformUpdateDomain { get; set; }

    [JsonPropertyName("rdpThumbPrint")]
    public string? RdpThumbPrint { get; set; }

    [JsonPropertyName("statuses")]
    public List<InstanceViewStatusModel>? Statuses { get; set; }

    [JsonPropertyName("vmAgent")]
    public VirtualMachineAgentInstanceViewModel? VmAgent { get; set; }

    [JsonPropertyName("vmHealth")]
    public VirtualMachineHealthStatusModel? VmHealth { get; set; }
}
