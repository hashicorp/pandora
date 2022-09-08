using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceWinRMConfigurationSchema
{

    [HclName("listener")]
    [Optional]
    public List<VirtualMachineScaleSetResourceWinRMListenerSchema> Listener { get; set; }

}
