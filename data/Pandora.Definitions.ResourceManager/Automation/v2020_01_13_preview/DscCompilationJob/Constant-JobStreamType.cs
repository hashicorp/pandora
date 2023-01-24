using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.DscCompilationJob;

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
