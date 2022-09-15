using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceWinRMListenerSchema
{

    [HclName("certificate_url")]
    [Optional]
    public string CertificateUrl { get; set; }


    [HclName("protocol")]
    [Optional]
    public string Protocol { get; set; }

}
