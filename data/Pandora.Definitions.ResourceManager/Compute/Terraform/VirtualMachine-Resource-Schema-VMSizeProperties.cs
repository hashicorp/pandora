using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVMSizePropertiesSchema
{

    [HclName("vcp_us_available")]
    [Optional]
    public int VCPUsAvailable { get; set; }


    [HclName("vcp_us_per_core")]
    [Optional]
    public int VCPUsPerCore { get; set; }

}
