using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSecurityProfileSchema
{

    [HclName("encryption_at_host")]
    [Optional]
    public bool EncryptionAtHost { get; set; }


    [HclName("security_type")]
    [Optional]
    public string SecurityType { get; set; }


    [HclName("uefi_settings")]
    [Optional]
    public VirtualMachineResourceUefiSettingsSchema UefiSettings { get; set; }

}
