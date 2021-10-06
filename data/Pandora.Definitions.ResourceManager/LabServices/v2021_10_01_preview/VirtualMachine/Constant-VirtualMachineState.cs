using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine
{
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
}
