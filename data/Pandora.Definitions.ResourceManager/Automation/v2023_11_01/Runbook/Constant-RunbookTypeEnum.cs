using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.Runbook;

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

    [Description("PowerShell72")]
    PowerShellSevenTwo,

    [Description("PowerShellWorkflow")]
    PowerShellWorkflow,

    [Description("Python3")]
    PythonThree,

    [Description("Python2")]
    PythonTwo,

    [Description("Script")]
    Script,
}
