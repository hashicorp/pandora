using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSchema
{

    [ForceNew]
    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineScaleSetResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [ForceNew]
    [HclName("automatic_repairs_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema AutomaticRepairsPolicy { get; set; }


    [ForceNew]
    [HclName("do_not_run_extensions_on_overprovisioned_v_ms")]
    [Optional]
    public bool DoNotRunExtensionsOnOverprovisionedVMs { get; set; }


    [HclName("host_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema HostGroup { get; set; }


    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("orchestration_mode")]
    [Optional]
    public string OrchestrationMode { get; set; }


    [ForceNew]
    [HclName("overprovision")]
    [Optional]
    public bool Overprovision { get; set; }


    [HclName("platform_fault_domain_count")]
    [Optional]
    public int PlatformFaultDomainCount { get; set; }


    [ForceNew]
    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [ForceNew]
    [HclName("scale_in_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceScaleInPolicySchema ScaleInPolicy { get; set; }


    [ForceNew]
    [HclName("single_placement_group")]
    [Optional]
    public bool SinglePlacementGroup { get; set; }


    [HclName("sku")]
    [Optional]
    public VirtualMachineScaleSetResourceSkuSchema Sku { get; set; }


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


    [ForceNew]
    [HclName("upgrade_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceUpgradePolicySchema UpgradePolicy { get; set; }


    [ForceNew]
    [HclName("virtual_machine_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema VirtualMachineProfile { get; set; }


    [HclName("zone_balance")]
    [Optional]
    public bool ZoneBalance { get; set; }

}
