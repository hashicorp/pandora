using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceDiagnosticsProfileSchema
{

    [HclName("boot_diagnostics")]
    [Optional]
    public VirtualMachineScaleSetResourceBootDiagnosticsSchema BootDiagnostics { get; set; }

}
