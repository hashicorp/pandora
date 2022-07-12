using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetPropertiesModel
{
    [JsonPropertyName("additionalCapabilities")]
    public AdditionalCapabilitiesModel? AdditionalCapabilities { get; set; }

    [JsonPropertyName("automaticRepairsPolicy")]
    public AutomaticRepairsPolicyModel? AutomaticRepairsPolicy { get; set; }

    [JsonPropertyName("doNotRunExtensionsOnOverprovisionedVMs")]
    public bool? DoNotRunExtensionsOnOverprovisionedVMs { get; set; }

    [JsonPropertyName("hostGroup")]
    public SubResourceModel? HostGroup { get; set; }

    [JsonPropertyName("orchestrationMode")]
    public OrchestrationModeConstant? OrchestrationMode { get; set; }

    [JsonPropertyName("overprovision")]
    public bool? Overprovision { get; set; }

    [JsonPropertyName("platformFaultDomainCount")]
    public int? PlatformFaultDomainCount { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("proximityPlacementGroup")]
    public SubResourceModel? ProximityPlacementGroup { get; set; }

    [JsonPropertyName("scaleInPolicy")]
    public ScaleInPolicyModel? ScaleInPolicy { get; set; }

    [JsonPropertyName("singlePlacementGroup")]
    public bool? SinglePlacementGroup { get; set; }

    [JsonPropertyName("spotRestorePolicy")]
    public SpotRestorePolicyModel? SpotRestorePolicy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeCreated")]
    public DateTime? TimeCreated { get; set; }

    [JsonPropertyName("uniqueId")]
    public string? UniqueId { get; set; }

    [JsonPropertyName("upgradePolicy")]
    public UpgradePolicyModel? UpgradePolicy { get; set; }

    [JsonPropertyName("virtualMachineProfile")]
    public VirtualMachineScaleSetVMProfileModel? VirtualMachineProfile { get; set; }

    [JsonPropertyName("zoneBalance")]
    public bool? ZoneBalance { get; set; }
}
