using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceWinRMConfigurationSchema
{

    [HclName("listener")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceWinRMListenerSchema>> Listener { get; set; }

}
