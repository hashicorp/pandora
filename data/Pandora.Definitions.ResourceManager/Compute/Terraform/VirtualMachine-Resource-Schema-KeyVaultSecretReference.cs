using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceKeyVaultSecretReferenceSchema
{

    [HclName("secret_url")]
    [Required]
    public string SecretUrl { get; set; }


    [HclName("source_vault_id")]
    [Required]
    public List<VirtualMachineResourceSubResourceSchema> SourceVaultId { get; set; }

}
