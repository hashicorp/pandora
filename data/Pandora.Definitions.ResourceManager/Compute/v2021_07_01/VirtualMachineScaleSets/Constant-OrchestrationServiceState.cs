using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OrchestrationServiceStateConstant
{
    [Description("NotRunning")]
    NotRunning,

    [Description("Running")]
    Running,

    [Description("Suspended")]
    Suspended,
}
