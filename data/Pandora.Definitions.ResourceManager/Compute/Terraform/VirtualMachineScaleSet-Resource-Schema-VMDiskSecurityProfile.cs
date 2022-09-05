using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVMDiskSecurityProfileSchema
{

    [HclName("disk_encryption_set_id")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSubResourceSchema> DiskEncryptionSetId { get; set; }


    [HclName("security_encryption_type")]
    [Optional]
    public string SecurityEncryptionType { get; set; }

}
