using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceKeyVaultKeyReferenceSchema
{

    [HclName("key_url")]
    [Required]
    public string KeyUrl { get; set; }


    [HclName("source_vault")]
    [Required]
    public VirtualMachineResourceSubResourceSchema SourceVault { get; set; }

}
