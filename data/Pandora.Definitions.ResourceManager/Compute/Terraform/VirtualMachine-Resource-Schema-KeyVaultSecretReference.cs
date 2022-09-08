using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceKeyVaultSecretReferenceSchema
{

    [HclName("secret_url")]
    [Required]
    public string SecretUrl { get; set; }


    [HclName("source_vault")]
    [Required]
    public VirtualMachineResourceSubResourceSchema SourceVault { get; set; }

}
