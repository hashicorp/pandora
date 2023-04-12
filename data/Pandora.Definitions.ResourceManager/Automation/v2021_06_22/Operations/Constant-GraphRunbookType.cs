using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.Operations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GraphRunbookTypeConstant
{
    [Description("GraphPowerShell")]
    GraphPowerShell,

    [Description("GraphPowerShellWorkflow")]
    GraphPowerShellWorkflow,
}
