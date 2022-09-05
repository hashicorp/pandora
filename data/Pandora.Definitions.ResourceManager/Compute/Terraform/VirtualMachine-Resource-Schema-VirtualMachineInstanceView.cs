using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineInstanceViewSchema
{

    [HclName("assigned_host")]
    [Optional]
    public string AssignedHost { get; set; }


    [HclName("boot_diagnostics")]
    [Optional]
    public List<VirtualMachineResourceBootDiagnosticsInstanceViewSchema> BootDiagnostics { get; set; }


    [HclName("computer_name")]
    [Optional]
    public string ComputerName { get; set; }


    [HclName("disk")]
    [Optional]
    public List<List<VirtualMachineResourceDiskInstanceViewSchema>> Disk { get; set; }


    [HclName("extension")]
    [Optional]
    public List<List<VirtualMachineResourceVirtualMachineExtensionInstanceViewSchema>> Extension { get; set; }


    [HclName("hyper_v_generation")]
    [Optional]
    public string HyperVGeneration { get; set; }


    [HclName("maintenance_redeploy_status")]
    [Optional]
    public List<VirtualMachineResourceMaintenanceRedeployStatusSchema> MaintenanceRedeployStatus { get; set; }


    [HclName("os_name")]
    [Optional]
    public string OsName { get; set; }


    [HclName("os_version")]
    [Optional]
    public string OsVersion { get; set; }


    [HclName("patch_status")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachinePatchStatusSchema> PatchStatus { get; set; }


    [HclName("platform_fault_domain")]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [HclName("platform_update_domain")]
    [Optional]
    public int PlatformUpdateDomain { get; set; }


    [HclName("rdp_thumb_print")]
    [Optional]
    public string RdpThumbPrint { get; set; }


    [HclName("statuse")]
    [Optional]
    public List<List<VirtualMachineResourceInstanceViewStatusSchema>> Statuse { get; set; }


    [HclName("vm_agent")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineAgentInstanceViewSchema> VmAgent { get; set; }


    [HclName("vm_health")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineHealthStatusSchema> VmHealth { get; set; }

}
