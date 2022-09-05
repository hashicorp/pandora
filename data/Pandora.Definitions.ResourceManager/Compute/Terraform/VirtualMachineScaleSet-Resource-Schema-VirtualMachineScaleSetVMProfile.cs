using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetVMProfileSchema
{

    [HclName("application_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceApplicationProfileSchema> ApplicationProfile { get; set; }


    [HclName("billing_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceBillingProfileSchema> BillingProfile { get; set; }


    [HclName("capacity_reservation")]
    [Optional]
    public List<VirtualMachineScaleSetResourceCapacityReservationProfileSchema> CapacityReservation { get; set; }


    [HclName("diagnostics_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceDiagnosticsProfileSchema> DiagnosticsProfile { get; set; }


    [HclName("eviction_policy")]
    [Optional]
    public string EvictionPolicy { get; set; }


    [HclName("extension_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionProfileSchema> ExtensionProfile { get; set; }


    [HclName("hardware_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetHardwareProfileSchema> HardwareProfile { get; set; }


    [HclName("license_type")]
    [Optional]
    public string LicenseType { get; set; }


    [HclName("network_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkProfileSchema> NetworkProfile { get; set; }


    [HclName("os_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetOSProfileSchema> OsProfile { get; set; }


    [HclName("priority")]
    [Optional]
    public string Priority { get; set; }


    [HclName("scheduled_events_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceScheduledEventsProfileSchema> ScheduledEventsProfile { get; set; }


    [HclName("security_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSecurityProfileSchema> SecurityProfile { get; set; }


    [HclName("storage_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetStorageProfileSchema> StorageProfile { get; set; }


    [HclName("user_data")]
    [Optional]
    public string UserData { get; set; }

}
