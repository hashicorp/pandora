using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceDiagnosticsProfileSchema
{

    [HclName("boot_diagnostics")]
    [Optional]
    public List<VirtualMachineResourceBootDiagnosticsSchema> BootDiagnostics { get; set; }

}
