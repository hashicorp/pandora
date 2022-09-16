using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineAgentInstanceViewSchema
{

    [HclName("extension_handler")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineExtensionHandlerInstanceViewSchema> ExtensionHandler { get; set; }


    [HclName("status")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Status { get; set; }


    [HclName("vm_agent_version")]
    [Optional]
    public string VmAgentVersion { get; set; }

}
