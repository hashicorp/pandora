using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceManagedDiskParametersSchema
{

    [HclName("disk_encryption_set")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema DiskEncryptionSet { get; set; }


    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("security_profile")]
    [Optional]
    public VirtualMachineResourceVMDiskSecurityProfileSchema SecurityProfile { get; set; }


    [HclName("storage_account_type")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.StorageAccountTypesConstant))]
    public string StorageAccountType { get; set; }

}
