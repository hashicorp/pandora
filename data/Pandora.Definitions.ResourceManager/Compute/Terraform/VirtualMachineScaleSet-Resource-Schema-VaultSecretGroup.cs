using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVaultSecretGroupSchema
{

    [HclName("source_vault_id")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSubResourceSchema> SourceVaultId { get; set; }


    [HclName("vault_certificate")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceVaultCertificateSchema>> VaultCertificate { get; set; }

}
