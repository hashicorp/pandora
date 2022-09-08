using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetManagedDiskParametersSchema
{

    [HclName("disk_encryption_set")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema DiskEncryptionSet { get; set; }


    [HclName("security_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceVMDiskSecurityProfileSchema SecurityProfile { get; set; }


    [HclName("storage_account_type")]
    [Optional]
    public string StorageAccountType { get; set; }

}
