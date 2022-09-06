using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceWindowsConfigurationSchema
{

    [HclName("additional_unattend_content")]
    [Optional]
    public List<VirtualMachineScaleSetResourceAdditionalUnattendContentSchema> AdditionalUnattendContent { get; set; }


    [HclName("automatic_updates_enabled")]
    [Optional]
    public bool AutomaticUpdatesEnabled { get; set; }


    [HclName("patch_settings")]
    [Optional]
    public VirtualMachineScaleSetResourcePatchSettingsSchema PatchSettings { get; set; }


    [HclName("provision_vm_agent")]
    [Optional]
    public bool ProvisionVMAgent { get; set; }


    [HclName("time_zone")]
    [Optional]
    public string TimeZone { get; set; }


    [HclName("win_rm")]
    [Optional]
    public VirtualMachineScaleSetResourceWinRMConfigurationSchema WinRM { get; set; }

}
