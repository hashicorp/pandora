using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetOSProfileSchema
{

    [HclName("admin_password")]
    [Optional]
    public string AdminPassword { get; set; }


    [HclName("admin_username")]
    [Optional]
    public string AdminUsername { get; set; }


    [HclName("computer_name_prefix")]
    [Optional]
    public string ComputerNamePrefix { get; set; }


    [HclName("custom_data")]
    [Optional]
    public string CustomData { get; set; }


    [HclName("extension_operations_enabled")]
    [Optional]
    public bool ExtensionOperationsEnabled { get; set; }


    [HclName("linux_configuration")]
    [Optional]
    public VirtualMachineScaleSetResourceLinuxConfigurationSchema LinuxConfiguration { get; set; }


    [HclName("secret")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVaultSecretGroupSchema> Secret { get; set; }


    [HclName("windows_configuration")]
    [Optional]
    public VirtualMachineScaleSetResourceWindowsConfigurationSchema WindowsConfiguration { get; set; }

}
