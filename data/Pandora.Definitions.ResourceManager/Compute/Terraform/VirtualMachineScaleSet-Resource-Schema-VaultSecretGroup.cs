using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVaultSecretGroupSchema
{

    [HclName("source_vault")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema SourceVault { get; set; }


    [HclName("vault_certificate")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVaultCertificateSchema> VaultCertificate { get; set; }

}
