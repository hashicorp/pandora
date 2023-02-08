using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Runbook;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunbookTypeEnumConstant
{
    [Description("Graph")]
    Graph,

    [Description("GraphPowerShell")]
    GraphPowerShell,

    [Description("GraphPowerShellWorkflow")]
    GraphPowerShellWorkflow,

    [Description("PowerShell")]
    PowerShell,

    [Description("PowerShellWorkflow")]
    PowerShellWorkflow,

    [Description("Python3")]
    PythonThree,

    [Description("Python2")]
    PythonTwo,

    [Description("Script")]
    Script,
}
