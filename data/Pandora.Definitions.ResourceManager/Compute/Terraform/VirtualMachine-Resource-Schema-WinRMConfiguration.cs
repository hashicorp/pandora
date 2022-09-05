using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceWinRMConfigurationSchema
{

    [HclName("listener")]
    [Optional]
    public List<List<VirtualMachineResourceWinRMListenerSchema>> Listener { get; set; }

}
