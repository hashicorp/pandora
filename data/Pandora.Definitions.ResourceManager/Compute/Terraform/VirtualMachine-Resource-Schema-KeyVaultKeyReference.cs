using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceKeyVaultKeyReferenceSchema
{

    [HclName("key_url")]
    [Required]
    public string KeyUrl { get; set; }


    [HclName("source_vault_id")]
    [Required]
    public VirtualMachineResourceSubResourceSchema SourceVaultId { get; set; }

}
