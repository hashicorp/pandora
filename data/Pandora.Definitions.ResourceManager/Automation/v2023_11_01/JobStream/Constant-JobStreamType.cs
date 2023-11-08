using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.JobStream;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStreamTypeConstant
{
    [Description("Any")]
    Any,

    [Description("Debug")]
    Debug,

    [Description("Error")]
    Error,

    [Description("Output")]
    Output,

    [Description("Progress")]
    Progress,

    [Description("Verbose")]
    Verbose,

    [Description("Warning")]
    Warning,
}
