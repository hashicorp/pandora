using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema
{

    [HclName("application_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceApplicationProfileSchema ApplicationProfile { get; set; }


    [HclName("billing_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceBillingProfileSchema BillingProfile { get; set; }


    [HclName("capacity_reservation")]
    [Optional]
    public VirtualMachineScaleSetResourceCapacityReservationProfileSchema CapacityReservation { get; set; }


    [HclName("diagnostics_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceDiagnosticsProfileSchema DiagnosticsProfile { get; set; }


    [HclName("eviction_policy")]
    [Optional]
    public string EvictionPolicy { get; set; }


    [HclName("extension_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionProfileSchema ExtensionProfile { get; set; }


    [HclName("hardware_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetHardwareProfileSchema HardwareProfile { get; set; }


    [HclName("license_type")]
    [Optional]
    public string LicenseType { get; set; }


    [HclName("network_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkProfileSchema NetworkProfile { get; set; }


    [HclName("os_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetOSProfileSchema OsProfile { get; set; }


    [HclName("priority")]
    [Optional]
    public string Priority { get; set; }


    [HclName("scheduled_events_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceScheduledEventsProfileSchema ScheduledEventsProfile { get; set; }


    [HclName("security_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceSecurityProfileSchema SecurityProfile { get; set; }


    [HclName("storage_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetStorageProfileSchema StorageProfile { get; set; }


    [HclName("user_data")]
    [Optional]
    public string UserData { get; set; }

}
