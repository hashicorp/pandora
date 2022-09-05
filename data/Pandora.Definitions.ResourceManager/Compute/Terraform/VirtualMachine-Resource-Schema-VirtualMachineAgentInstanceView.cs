using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineAgentInstanceViewSchema
{

    [HclName("extension_handler")]
    [Optional]
    public List<List<VirtualMachineResourceVirtualMachineExtensionHandlerInstanceViewSchema>> ExtensionHandler { get; set; }


    [HclName("statuse")]
    [Optional]
    public List<List<VirtualMachineResourceInstanceViewStatusSchema>> Statuse { get; set; }


    [HclName("vm_agent_version")]
    [Optional]
    public string VmAgentVersion { get; set; }

}
