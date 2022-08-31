using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMRunCommands;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExecutionStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("TimedOut")]
    TimedOut,

    [Description("Unknown")]
    Unknown,
}
