using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSchema
{

    [ForceNew]
    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [ForceNew]
    [HclName("application_profile")]
    [Optional]
    public VirtualMachineResourceApplicationProfileSchema ApplicationProfile { get; set; }


    [ForceNew]
    [HclName("availability_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema AvailabilitySet { get; set; }


    [ForceNew]
    [HclName("billing_profile")]
    [Optional]
    public VirtualMachineResourceBillingProfileSchema BillingProfile { get; set; }


    [ForceNew]
    [HclName("capacity_reservation")]
    [Optional]
    public VirtualMachineResourceCapacityReservationProfileSchema CapacityReservation { get; set; }


    [ForceNew]
    [HclName("diagnostics_profile")]
    [Optional]
    public VirtualMachineResourceDiagnosticsProfileSchema DiagnosticsProfile { get; set; }


    [ForceNew]
    [HclName("eviction_policy")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.VirtualMachineEvictionPolicyTypesConstant))]
    public string EvictionPolicy { get; set; }


    [ForceNew]
    [HclName("extensions_time_budget")]
    [Optional]
    public string ExtensionsTimeBudget { get; set; }


    [ForceNew]
    [HclName("hardware_profile")]
    [Optional]
    public VirtualMachineResourceHardwareProfileSchema HardwareProfile { get; set; }


    [ForceNew]
    [HclName("host")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema Host { get; set; }


    [ForceNew]
    [HclName("host_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema HostGroup { get; set; }


    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [Computed]
    [HclName("instance_view")]
    public VirtualMachineResourceVirtualMachineInstanceViewSchema InstanceView { get; set; }


    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [ForceNew]
    [HclName("network_profile")]
    [Optional]
    public VirtualMachineResourceNetworkProfileSchema NetworkProfile { get; set; }


    [ForceNew]
    [HclName("os_profile")]
    [Optional]
    public VirtualMachineResourceOSProfileSchema OsProfile { get; set; }


    [ForceNew]
    [HclName("platform_fault_domain")]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [ForceNew]
    [HclName("priority")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.VirtualMachinePriorityTypesConstant))]
    public string Priority { get; set; }


    [ForceNew]
    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [ForceNew]
    [HclName("scale_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ScaleSet { get; set; }


    [ForceNew]
    [HclName("scheduled_events_profile")]
    [Optional]
    public VirtualMachineResourceScheduledEventsProfileSchema ScheduledEventsProfile { get; set; }


    [ForceNew]
    [HclName("security_profile")]
    [Optional]
    public VirtualMachineResourceSecurityProfileSchema SecurityProfile { get; set; }


    [ForceNew]
    [HclName("storage_profile")]
    [Optional]
    public VirtualMachineResourceStorageProfileSchema StorageProfile { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [HclName("time_created")]
    public System.DateTime TimeCreated { get; set; }


    [ForceNew]
    [HclName("user_data")]
    [Optional]
    public string UserData { get; set; }


    [Computed]
    [HclName("vm_id")]
    public string VmId { get; set; }

}
