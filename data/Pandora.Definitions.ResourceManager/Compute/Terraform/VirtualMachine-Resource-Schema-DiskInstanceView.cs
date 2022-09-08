using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceDiskInstanceViewSchema
{

    [HclName("encryption_setting")]
    [Optional]
    public List<VirtualMachineResourceDiskEncryptionSettingsSchema> EncryptionSetting { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("statuse")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Statuse { get; set; }

}
