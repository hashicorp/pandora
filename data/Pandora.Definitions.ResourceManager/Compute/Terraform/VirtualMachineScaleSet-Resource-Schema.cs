using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSchema
{

    [HclName("additional_capabilities")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [HclName("automatic_repairs_policy")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema AutomaticRepairsPolicy { get; set; }


    [HclName("do_not_run_extensions_on_overprovisioned_v_ms")]
    [ForceNew]
    [Optional]
    public bool DoNotRunExtensionsOnOverprovisionedVMs { get; set; }


    [HclName("host_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema HostGroup { get; set; }


    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [HclName("location")]
    [ForceNew]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [HclName("name")]
    [ForceNew]
    [Required]
    public string Name { get; set; }


    [HclName("orchestration_mode")]
    [Optional]
    public string OrchestrationMode { get; set; }


    [HclName("overprovision")]
    [ForceNew]
    [Optional]
    public bool Overprovision { get; set; }


    [HclName("platform_fault_domain_count")]
    [Optional]
    public int PlatformFaultDomainCount { get; set; }


    [HclName("proximity_placement_group")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [HclName("scale_in_policy")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceScaleInPolicySchema ScaleInPolicy { get; set; }


    [HclName("single_placement_group")]
    [ForceNew]
    [Optional]
    public bool SinglePlacementGroup { get; set; }


    [HclName("spot_restore_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceSpotRestorePolicySchema SpotRestorePolicy { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [HclName("time_created")]
    [Optional]
    public System.DateTime TimeCreated { get; set; }


    [HclName("unique_id")]
    [Optional]
    public string UniqueId { get; set; }


    [HclName("upgrade_policy")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceUpgradePolicySchema UpgradePolicy { get; set; }


    [HclName("virtual_machine_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema VirtualMachineProfile { get; set; }


    [HclName("zone_balance")]
    [Optional]
    public bool ZoneBalance { get; set; }

}
