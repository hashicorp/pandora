using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptExecutionProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

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
