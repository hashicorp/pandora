using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSchema
{

    [Documentation("Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type.")]
    [ForceNew]
    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineScaleSetResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [Documentation("Policy for automatic repairs.")]
    [ForceNew]
    [HclName("automatic_repairs_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema AutomaticRepairsPolicy { get; set; }


    [Documentation("When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.")]
    [ForceNew]
    [HclName("do_not_run_extensions_on_overprovisioned_v_ms")]
    [Optional]
    public bool DoNotRunExtensionsOnOverprovisionedVMs { get; set; }


    [Documentation("Specifies information about the dedicated host group that the virtual machine scale set resides in. <br><br>Minimum api-version: 2020-06-01.")]
    [HclName("host_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema HostGroup { get; set; }


    [Documentation("The identity of the virtual machine scale set, if configured.")]
    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [Documentation("The Azure Region where the resource should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("The name which should be used for this resource")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the orchestration mode for the virtual machine scale set.")]
    [HclName("orchestration_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.OrchestrationModeConstant))]
    public string OrchestrationMode { get; set; }


    [Documentation("Specifies whether the Virtual Machine Scale Set should be overprovisioned.")]
    [ForceNew]
    [HclName("overprovision")]
    [Optional]
    public bool Overprovision { get; set; }


    [Documentation("Fault Domain count for each placement group.")]
    [HclName("platform_fault_domain_count")]
    [Optional]
    public int PlatformFaultDomainCount { get; set; }


    [Documentation("Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. <br><br>Minimum api-version: 2018-04-01.")]
    [ForceNew]
    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("Specifies the policies applied when scaling in Virtual Machines in the Virtual Machine Scale Set.")]
    [ForceNew]
    [HclName("scale_in_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceScaleInPolicySchema ScaleInPolicy { get; set; }


    [Documentation("When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true.")]
    [ForceNew]
    [HclName("single_placement_group")]
    [Optional]
    public bool SinglePlacementGroup { get; set; }


    [Documentation("The virtual machine scale set sku.")]
    [HclName("sku")]
    [Optional]
    public VirtualMachineScaleSetResourceSkuSchema Sku { get; set; }


    [Documentation("Specifies the Spot Restore properties for the virtual machine scale set.")]
    [HclName("spot_restore_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceSpotRestorePolicySchema SpotRestorePolicy { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Resource.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [Documentation("Specifies the time at which the Virtual Machine Scale Set resource was created.<br><br>Minimum api-version: 2021-11-01.")]
    [HclName("time_created")]
    public System.DateTime TimeCreated { get; set; }


    [Computed]
    [Documentation("Specifies the ID which uniquely identifies a Virtual Machine Scale Set.")]
    [HclName("unique_id")]
    public string UniqueId { get; set; }


    [Documentation("The upgrade policy.")]
    [ForceNew]
    [HclName("upgrade_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceUpgradePolicySchema UpgradePolicy { get; set; }


    [Documentation("The virtual machine profile.")]
    [ForceNew]
    [HclName("virtual_machine_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema VirtualMachineProfile { get; set; }


    [Documentation("Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage. zoneBalance property can only be set if the zones property of the scale set contains more than one zone. If there are no zones or only one zone specified, then zoneBalance property should not be set.")]
    [HclName("zone_balance")]
    [Optional]
    public bool ZoneBalance { get; set; }

}
