using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
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
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.StorageAccountTypesConstant))]
    public string StorageAccountType { get; set; }

}
