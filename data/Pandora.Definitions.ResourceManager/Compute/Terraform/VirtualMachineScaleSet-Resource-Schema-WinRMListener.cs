using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceWinRMListenerSchema
{

    [HclName("certificate_url")]
    [Optional]
    public string CertificateUrl { get; set; }


    [HclName("protocol")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.ProtocolTypesConstant))]
    public string Protocol { get; set; }

}
