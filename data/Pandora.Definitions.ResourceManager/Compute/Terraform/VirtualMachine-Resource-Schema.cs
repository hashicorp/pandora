using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;
using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.Compute;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSchema
{

    [PossibleValuesFromConstant(typeof(CachingTypesConstant))]
    [HclName("additional_capabilities")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [HclName("application_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceApplicationProfileSchema ApplicationProfile { get; set; }


    [HclName("availability_set_id")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSubResourceSchema AvailabilitySetId { get; set; }


    [HclName("billing_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceBillingProfileSchema BillingProfile { get; set; }


    [HclName("capacity_reservation")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceCapacityReservationProfileSchema CapacityReservation { get; set; }


    [HclName("diagnostics_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceDiagnosticsProfileSchema DiagnosticsProfile { get; set; }


    [HclName("eviction_policy")]
    [ForceNew]
    [Optional]
    public string EvictionPolicy { get; set; }


    [HclName("extensions_time_budget")]
    [ForceNew]
    [Optional]
    public string ExtensionsTimeBudget { get; set; }


    [HclName("hardware_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceHardwareProfileSchema HardwareProfile { get; set; }


    [HclName("host_group_id")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSubResourceSchema HostGroupId { get; set; }


    [HclName("host_id")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSubResourceSchema HostId { get; set; }


    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [HclName("instance_view")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceVirtualMachineInstanceViewSchema InstanceView { get; set; }


    [HclName("location")]
    [ForceNew]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [HclName("name")]
    [ForceNew]
    [Required]
    public string Name { get; set; }


    [HclName("network_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceNetworkProfileSchema NetworkProfile { get; set; }


    [HclName("os_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceOSProfileSchema OsProfile { get; set; }


    [HclName("platform_fault_domain")]
    [ForceNew]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [HclName("priority")]
    [ForceNew]
    [Optional]
    public string Priority { get; set; }


    [HclName("proximity_placement_group_id")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ProximityPlacementGroupId { get; set; }


    [HclName("scheduled_events_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceScheduledEventsProfileSchema ScheduledEventsProfile { get; set; }


    [HclName("security_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSecurityProfileSchema SecurityProfile { get; set; }


    [HclName("storage_profile")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceStorageProfileSchema StorageProfile { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [HclName("time_created")]
    [ForceNew]
    [Optional]
    public System.DateTime TimeCreated { get; set; }


    [HclName("user_data")]
    [ForceNew]
    [Optional]
    public string UserData { get; set; }


    [HclName("virtual_machine_scale_set_id")]
    [ForceNew]
    [Optional]
    public VirtualMachineResourceSubResourceSchema VirtualMachineScaleSetId { get; set; }


    [HclName("vm_id")]
    [ForceNew]
    [Optional]
    public string VmId { get; set; }

}
