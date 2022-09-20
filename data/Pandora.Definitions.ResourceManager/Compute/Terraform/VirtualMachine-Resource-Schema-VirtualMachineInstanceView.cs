using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineInstanceViewSchema
{

    [HclName("assigned_host")]
    public string AssignedHost { get; set; }


    [HclName("boot_diagnostics")]
    [Optional]
    public VirtualMachineResourceBootDiagnosticsInstanceViewSchema BootDiagnostics { get; set; }


    [HclName("computer_name")]
    [Optional]
    public string ComputerName { get; set; }


    [HclName("disk")]
    [Optional]
    public List<VirtualMachineResourceDiskInstanceViewSchema> Disk { get; set; }


    [HclName("extension")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineExtensionInstanceViewSchema> Extension { get; set; }


    [HclName("hyper_v_generation")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.HyperVGenerationTypeConstant))]
    public string HyperVGeneration { get; set; }


    [HclName("maintenance_redeploy_status")]
    [Optional]
    public VirtualMachineResourceMaintenanceRedeployStatusSchema MaintenanceRedeployStatus { get; set; }


    [HclName("os_name")]
    [Optional]
    public string OsName { get; set; }


    [HclName("os_version")]
    [Optional]
    public string OsVersion { get; set; }


    [HclName("patch_status")]
    [Optional]
    public VirtualMachineResourceVirtualMachinePatchStatusSchema PatchStatus { get; set; }


    [HclName("platform_fault_domain")]
    [Optional]
    public int PlatformFaultDomain { get; set; }


    [HclName("platform_update_domain")]
    [Optional]
    public int PlatformUpdateDomain { get; set; }


    [HclName("rdp_thumb_print")]
    [Optional]
    public string RdpThumbPrint { get; set; }


    [HclName("status")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Status { get; set; }


    [HclName("vm_agent")]
    [Optional]
    public VirtualMachineResourceVirtualMachineAgentInstanceViewSchema VmAgent { get; set; }


    [HclName("vm_health")]
    public VirtualMachineResourceVirtualMachineHealthStatusSchema VmHealth { get; set; }

}
