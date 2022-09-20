using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSchema
{

    [Documentation("Specifies additional capabilities enabled or disabled on the virtual machine.")]
    [ForceNew]
    [HclName("additional_capabilities")]
    [Optional]
    public VirtualMachineResourceAdditionalCapabilitiesSchema AdditionalCapabilities { get; set; }


    [Documentation("Specifies the gallery applications that should be made available to the VM/VMSS")]
    [ForceNew]
    [HclName("application_profile")]
    [Optional]
    public VirtualMachineResourceApplicationProfileSchema ApplicationProfile { get; set; }


    [Documentation("Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Availability sets overview](https://docs.microsoft.com/azure/virtual-machines/availability-set-overview). <br><br> For more information on Azure planned maintenance, see [Maintenance and updates for Virtual Machines in Azure](https://docs.microsoft.com/azure/virtual-machines/maintenance-and-updates) <br><br> Currently, a VM can only be added to availability set at creation time. The availability set to which the VM is being added should be under the same resource group as the availability set resource. An existing VM cannot be added to an availability set. <br><br>This property cannot exist along with a non-null properties.virtualMachineScaleSet reference.")]
    [ForceNew]
    [HclName("availability_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema AvailabilitySet { get; set; }


    [Documentation("Specifies the billing related details of a Azure Spot virtual machine. <br><br>Minimum api-version: 2019-03-01.")]
    [ForceNew]
    [HclName("billing_profile")]
    [Optional]
    public VirtualMachineResourceBillingProfileSchema BillingProfile { get; set; }


    [Documentation("Specifies information about the capacity reservation that is used to allocate virtual machine. <br><br>Minimum api-version: 2021-04-01.")]
    [ForceNew]
    [HclName("capacity_reservation")]
    [Optional]
    public VirtualMachineResourceCapacityReservationProfileSchema CapacityReservation { get; set; }


    [Documentation("Specifies the boot diagnostic settings state. <br><br>Minimum api-version: 2015-06-15.")]
    [ForceNew]
    [HclName("diagnostics_profile")]
    [Optional]
    public VirtualMachineResourceDiagnosticsProfileSchema DiagnosticsProfile { get; set; }


    [Documentation("Specifies the eviction policy for the Azure Spot virtual machine and Azure Spot scale set. <br><br>For Azure Spot virtual machines, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2019-03-01. <br><br>For Azure Spot scale sets, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2017-10-30-preview.")]
    [ForceNew]
    [HclName("eviction_policy")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.VirtualMachineEvictionPolicyTypesConstant))]
    public string EvictionPolicy { get; set; }


    [Documentation("Specifies the time alloted for all extensions to start. The time duration should be between 15 minutes and 120 minutes (inclusive) and should be specified in ISO 8601 format. The default value is 90 minutes (PT1H30M). <br><br> Minimum api-version: 2020-06-01")]
    [ForceNew]
    [HclName("extensions_time_budget")]
    [Optional]
    public string ExtensionsTimeBudget { get; set; }


    [Documentation("Specifies the hardware settings for the virtual machine.")]
    [ForceNew]
    [HclName("hardware_profile")]
    [Optional]
    public VirtualMachineResourceHardwareProfileSchema HardwareProfile { get; set; }


    [Documentation("Specifies information about the dedicated host that the virtual machine resides in. <br><br>Minimum api-version: 2018-10-01.")]
    [ForceNew]
    [HclName("host")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema Host { get; set; }


    [Documentation("Specifies information about the dedicated host group that the virtual machine resides in. <br><br>Minimum api-version: 2020-06-01. <br><br>NOTE: User cannot specify both host and hostGroup properties.")]
    [ForceNew]
    [HclName("host_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema HostGroup { get; set; }


    [Documentation("The identity of the virtual machine, if configured.")]
    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [Computed]
    [Documentation("The virtual machine instance view.")]
    [HclName("instance_view")]
    public VirtualMachineResourceVirtualMachineInstanceViewSchema InstanceView { get; set; }


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


    [Documentation("Specifies the network interfaces of the virtual machine.")]
    [ForceNew]
    [HclName("network_profile")]
    [Optional]
    public VirtualMachineResourceNetworkProfileSchema NetworkProfile { get; set; }


    [Documentation("Specifies the operating system settings used while creating the virtual machine. Some of the settings cannot be changed once VM is provisioned.")]
    [ForceNew]
    [HclName("os_profile")]
    [Optional]
    public VirtualMachineResourceOSProfileSchema OsProfile { get; set; }


    [Documentation("Specifies the scale set logical fault domain into which the Virtual Machine will be created. By default, the Virtual Machine will by automatically assigned to a fault domain that best maintains balance across available fault domains.<br><li>This is applicable only if the 'virtualMachineScaleSet' property of this Virtual Machine is set.<li>The Virtual Machine Scale Set that is referenced, must have 'platformFaultDomainCount' &gt; 1.<li>This property cannot be updated once the Virtual Machine is created.<li>Fault domain assignment can be viewed in the Virtual Machine Instance View.<br><br>Minimum api‐version: 2020‐12‐01")]
    [ForceNew]
    [HclName("platform_fault_domain")]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [Documentation("Specifies the priority for the virtual machine. <br><br>Minimum api-version: 2019-03-01")]
    [ForceNew]
    [HclName("priority")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.VirtualMachinePriorityTypesConstant))]
    public string Priority { get; set; }


    [Documentation("Specifies information about the proximity placement group that the virtual machine should be assigned to. <br><br>Minimum api-version: 2018-04-01.")]
    [ForceNew]
    [HclName("proximity_placement_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ProximityPlacementGroup { get; set; }


    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("Specifies information about the virtual machine scale set that the virtual machine should be assigned to. Virtual machines specified in the same virtual machine scale set are allocated to different nodes to maximize availability. Currently, a VM can only be added to virtual machine scale set at creation time. An existing VM cannot be added to a virtual machine scale set. <br><br>This property cannot exist along with a non-null properties.availabilitySet reference. <br><br>Minimum api‐version: 2019‐03‐01")]
    [ForceNew]
    [HclName("scale_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema ScaleSet { get; set; }


    [Documentation("Specifies Scheduled Event related configurations.")]
    [ForceNew]
    [HclName("scheduled_events_profile")]
    [Optional]
    public VirtualMachineResourceScheduledEventsProfileSchema ScheduledEventsProfile { get; set; }


    [Documentation("Specifies the Security related profile settings for the virtual machine.")]
    [ForceNew]
    [HclName("security_profile")]
    [Optional]
    public VirtualMachineResourceSecurityProfileSchema SecurityProfile { get; set; }


    [Documentation("Specifies the storage settings for the virtual machine disks.")]
    [ForceNew]
    [HclName("storage_profile")]
    [Optional]
    public VirtualMachineResourceStorageProfileSchema StorageProfile { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Resource.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [Documentation("Specifies the time at which the Virtual Machine resource was created.<br><br>Minimum api-version: 2021-11-01.")]
    [HclName("time_created")]
    public System.DateTime TimeCreated { get; set; }


    [Documentation("UserData for the VM, which must be base-64 encoded. Customer should not pass any secrets in here. <br><br>Minimum api-version: 2021-03-01")]
    [ForceNew]
    [HclName("user_data")]
    [Optional]
    public string UserData { get; set; }


    [Computed]
    [Documentation("Specifies the VM unique ID which is a 128-bits identifier that is encoded and stored in all Azure IaaS VMs SMBIOS and can be read using platform BIOS commands.")]
    [HclName("vm_id")]
    public string VmId { get; set; }

}
