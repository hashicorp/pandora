using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptExecutionProvisioningStateConstant
{
    [Description("Cancelled")]
    Cancelled,

    [Description("Cancelling")]
    Cancelling,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,
}
