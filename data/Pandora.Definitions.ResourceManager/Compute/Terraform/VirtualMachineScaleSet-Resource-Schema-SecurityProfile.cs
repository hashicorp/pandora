using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSecurityProfileSchema
{

    [HclName("encryption_at_host")]
    [Optional]
    public bool EncryptionAtHost { get; set; }


    [HclName("security_type")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.SecurityTypesConstant))]
    public string SecurityType { get; set; }


    [HclName("uefi_settings")]
    [Optional]
    public VirtualMachineScaleSetResourceUefiSettingsSchema UefiSettings { get; set; }

}
