using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetPropertiesSchema
{

    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineScaleSetResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [HclName("automatic_repairs_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema AutomaticRepairsPolicy { get; set; }


    [HclName("do_not_run_extensions_on_overprovisioned_v_ms")]
    [Optional]
    public bool DoNotRunExtensionsOnOverprovisionedVMs { get; set; }


    [HclName("host_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema HostGroup { get; set; }


    [HclName("orchestration_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.OrchestrationModeConstant))]
    public string OrchestrationMode { get; set; }


    [HclName("overprovision")]
    [Optional]
    public bool Overprovision { get; set; }


    [HclName("platform_fault_domain_count")]
    [Optional]
    public int PlatformFaultDomainCount { get; set; }


    [HclName("provisioning_state")]
    [Optional]
    public string ProvisioningState { get; set; }


    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [HclName("scale_in_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceScaleInPolicySchema ScaleInPolicy { get; set; }


    [HclName("single_placement_group")]
    [Optional]
    public bool SinglePlacementGroup { get; set; }


    [HclName("spot_restore_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceSpotRestorePolicySchema SpotRestorePolicy { get; set; }


    [HclName("time_created")]
    [Optional]
    public System.DateTime TimeCreated { get; set; }


    [HclName("unique_id")]
    [Optional]
    public string UniqueId { get; set; }


    [HclName("upgrade_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceUpgradePolicySchema UpgradePolicy { get; set; }


    [HclName("virtual_machine_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema VirtualMachineProfile { get; set; }


    [HclName("zone_balance")]
    [Optional]
    public bool ZoneBalance { get; set; }

}
