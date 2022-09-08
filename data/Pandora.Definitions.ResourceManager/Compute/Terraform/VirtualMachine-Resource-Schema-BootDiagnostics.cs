using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceBootDiagnosticsSchema
{

    [HclName("enabled")]
    [Optional]
    public bool Enabled { get; set; }


    [HclName("storage_uri")]
    [Optional]
    public string StorageUri { get; set; }

}
