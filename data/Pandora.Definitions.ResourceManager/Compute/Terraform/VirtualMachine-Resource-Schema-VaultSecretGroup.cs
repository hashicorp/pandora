using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVaultSecretGroupSchema
{

    [HclName("source_vault_id")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema SourceVaultId { get; set; }


    [HclName("vault_certificate")]
    [Optional]
    public List<VirtualMachineResourceVaultCertificateSchema> VaultCertificate { get; set; }

}
