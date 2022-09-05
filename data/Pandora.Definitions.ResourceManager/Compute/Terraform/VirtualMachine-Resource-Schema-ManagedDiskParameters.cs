using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceManagedDiskParametersSchema
{

    [HclName("disk_encryption_set_id")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> DiskEncryptionSetId { get; set; }


    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("security_profile")]
    [Optional]
    public List<VirtualMachineResourceVMDiskSecurityProfileSchema> SecurityProfile { get; set; }


    [HclName("storage_account_type")]
    [Optional]
    public string StorageAccountType { get; set; }

}
