using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVaultCertificateSchema
{

    [HclName("certificate_store")]
    [Optional]
    public string CertificateStore { get; set; }


    [HclName("certificate_url")]
    [Optional]
    public string CertificateUrl { get; set; }

}
