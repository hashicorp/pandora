using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceBootDiagnosticsSchema
{

    [HclName("storage_uri")]
    [Optional]
    public string StorageUri { get; set; }


    [HclName("d_enabled")]
    [Optional]
    public bool dEnabled { get; set; }

}
