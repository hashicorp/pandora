using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVMDiskSecurityProfileSchema
{

    [HclName("disk_encryption_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema DiskEncryptionSet { get; set; }


    [HclName("security_encryption_type")]
    [Optional]
    public string SecurityEncryptionType { get; set; }

}
