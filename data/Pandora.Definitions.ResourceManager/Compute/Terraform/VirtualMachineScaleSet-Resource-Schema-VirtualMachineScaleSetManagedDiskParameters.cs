using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetManagedDiskParametersSchema
{

    [HclName("disk_encryption_set_id")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSubResourceSchema> DiskEncryptionSetId { get; set; }


    [HclName("security_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVMDiskSecurityProfileSchema> SecurityProfile { get; set; }


    [HclName("storage_account_type")]
    [Optional]
    public string StorageAccountType { get; set; }

}
