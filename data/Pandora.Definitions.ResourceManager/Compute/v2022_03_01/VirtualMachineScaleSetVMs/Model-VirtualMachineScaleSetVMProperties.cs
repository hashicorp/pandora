using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineScaleSetVMPropertiesModel
{
    [JsonPropertyName("additionalCapabilities")]
    public AdditionalCapabilitiesModel? AdditionalCapabilities { get; set; }

    [JsonPropertyName("availabilitySet")]
    public SubResourceModel? AvailabilitySet { get; set; }

    [JsonPropertyName("diagnosticsProfile")]
    public DiagnosticsProfileModel? DiagnosticsProfile { get; set; }

    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileModel? HardwareProfile { get; set; }

    [JsonPropertyName("instanceView")]
    public VirtualMachineScaleSetVMInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("latestModelApplied")]
    public bool? LatestModelApplied { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("modelDefinitionApplied")]
    public string? ModelDefinitionApplied { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("networkProfileConfiguration")]
    public VirtualMachineScaleSetVMNetworkProfileConfigurationModel? NetworkProfileConfiguration { get; set; }

    [JsonPropertyName("osProfile")]
    public OSProfileModel? OsProfile { get; set; }

    [JsonPropertyName("protectionPolicy")]
    public VirtualMachineScaleSetVMProtectionPolicyModel? ProtectionPolicy { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("securityProfile")]
    public SecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("userData")]
    public string? UserData { get; set; }

    [JsonPropertyName("vmId")]
    public string? VmId { get; set; }
}
