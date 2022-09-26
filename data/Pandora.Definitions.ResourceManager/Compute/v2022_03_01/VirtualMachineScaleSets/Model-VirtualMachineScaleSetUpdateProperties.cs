using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetUpdatePropertiesModel
{
    [JsonPropertyName("additionalCapabilities")]
    public AdditionalCapabilitiesModel? AdditionalCapabilities { get; set; }

    [JsonPropertyName("automaticRepairsPolicy")]
    public AutomaticRepairsPolicyModel? AutomaticRepairsPolicy { get; set; }

    [JsonPropertyName("doNotRunExtensionsOnOverprovisionedVMs")]
    public bool? DoNotRunExtensionsOnOverprovisionedVMs { get; set; }

    [JsonPropertyName("overprovision")]
    public bool? Overprovision { get; set; }

    [JsonPropertyName("proximityPlacementGroup")]
    public SubResourceModel? ProximityPlacementGroup { get; set; }

    [JsonPropertyName("scaleInPolicy")]
    public ScaleInPolicyModel? ScaleInPolicy { get; set; }

    [JsonPropertyName("singlePlacementGroup")]
    public bool? SinglePlacementGroup { get; set; }

    [JsonPropertyName("upgradePolicy")]
    public UpgradePolicyModel? UpgradePolicy { get; set; }

    [JsonPropertyName("virtualMachineProfile")]
    public VirtualMachineScaleSetUpdateVMProfileModel? VirtualMachineProfile { get; set; }
}
