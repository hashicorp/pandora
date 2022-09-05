using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceOSProfileSchema
{

    [HclName("admin_password")]
    [Optional]
    public string AdminPassword { get; set; }


    [HclName("admin_username")]
    [Optional]
    public string AdminUsername { get; set; }


    [HclName("computer_name")]
    [Optional]
    public string ComputerName { get; set; }


    [HclName("custom_data")]
    [Optional]
    public string CustomData { get; set; }


    [HclName("extension_operations_enabled")]
    [Optional]
    public bool ExtensionOperationsEnabled { get; set; }


    [HclName("linux_configuration")]
    [Optional]
    public List<VirtualMachineResourceLinuxConfigurationSchema> LinuxConfiguration { get; set; }


    [HclName("require_guest_provision_signal")]
    [Optional]
    public bool RequireGuestProvisionSignal { get; set; }


    [HclName("secret")]
    [Optional]
    public List<List<VirtualMachineResourceVaultSecretGroupSchema>> Secret { get; set; }


    [HclName("windows_configuration")]
    [Optional]
    public List<VirtualMachineResourceWindowsConfigurationSchema> WindowsConfiguration { get; set; }

}
