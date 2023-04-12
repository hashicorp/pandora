using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Operations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GraphRunbookTypeConstant
{
    [Description("GraphPowerShell")]
    GraphPowerShell,

    [Description("GraphPowerShellWorkflow")]
    GraphPowerShellWorkflow,
}
