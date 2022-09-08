using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePropertiesSchema
{

    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [HclName("application_profile")]
    [Optional]
    public VirtualMachineResourceApplicationProfileSchema ApplicationProfile { get; set; }


    [HclName("availability_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema AvailabilitySet { get; set; }


    [HclName("billing_profile")]
    [Optional]
    public VirtualMachineResourceBillingProfileSchema BillingProfile { get; set; }


    [HclName("capacity_reservation")]
    [Optional]
    public VirtualMachineResourceCapacityReservationProfileSchema CapacityReservation { get; set; }


    [HclName("diagnostics_profile")]
    [Optional]
    public VirtualMachineResourceDiagnosticsProfileSchema DiagnosticsProfile { get; set; }


    [HclName("eviction_policy")]
    [Optional]
    public string EvictionPolicy { get; set; }


    [HclName("extensions_time_budget")]
    [Optional]
    public string ExtensionsTimeBudget { get; set; }


    [HclName("hardware_profile")]
    [Optional]
    public VirtualMachineResourceHardwareProfileSchema HardwareProfile { get; set; }


    [HclName("host")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema Host { get; set; }


    [HclName("host_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema HostGroup { get; set; }


    [HclName("instance_view")]
    [Optional]
    public VirtualMachineResourceVirtualMachineInstanceViewSchema InstanceView { get; set; }


    [HclName("license_type")]
    [Optional]
    public string LicenseType { get; set; }


    [HclName("network_profile")]
    [Optional]
    public VirtualMachineResourceNetworkProfileSchema NetworkProfile { get; set; }


    [HclName("os_profile")]
    [Optional]
    public VirtualMachineResourceOSProfileSchema OsProfile { get; set; }


    [HclName("platform_fault_domain")]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [HclName("priority")]
    [Optional]
    public string Priority { get; set; }


    [HclName("provisioning_state")]
    [Optional]
    public string ProvisioningState { get; set; }


    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [HclName("scale_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ScaleSet { get; set; }


    [HclName("scheduled_events_profile")]
    [Optional]
    public VirtualMachineResourceScheduledEventsProfileSchema ScheduledEventsProfile { get; set; }


    [HclName("security_profile")]
    [Optional]
    public VirtualMachineResourceSecurityProfileSchema SecurityProfile { get; set; }


    [HclName("storage_profile")]
    [Optional]
    public VirtualMachineResourceStorageProfileSchema StorageProfile { get; set; }


    [HclName("time_created")]
    [Optional]
    public System.DateTime TimeCreated { get; set; }


    [HclName("user_data")]
    [Optional]
    public string UserData { get; set; }


    [HclName("vm_id")]
    [Optional]
    public string VmId { get; set; }

}
