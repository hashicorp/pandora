using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceLinuxConfigurationSchema
{

    [HclName("password_authentication_disabled")]
    [Optional]
    public bool PasswordAuthenticationDisabled { get; set; }


    [HclName("patch_settings")]
    [Optional]
    public List<VirtualMachineScaleSetResourceLinuxPatchSettingsSchema> PatchSettings { get; set; }


    [HclName("provision_vm_agent")]
    [Optional]
    public bool ProvisionVMAgent { get; set; }


    [HclName("ssh")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSshConfigurationSchema> Ssh { get; set; }

}
