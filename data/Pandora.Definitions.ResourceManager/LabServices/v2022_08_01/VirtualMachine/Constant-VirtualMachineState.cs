using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.VirtualMachine;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineStateConstant
{
    [Description("Redeploying")]
    Redeploying,

    [Description("Reimaging")]
    Reimaging,

    [Description("ResettingPassword")]
    ResettingPassword,

    [Description("Running")]
    Running,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
