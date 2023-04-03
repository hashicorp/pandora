using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.ActivityLogs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventLevelConstant
{
    [Description("Critical")]
    Critical,

    [Description("Error")]
    Error,

    [Description("Informational")]
    Informational,

    [Description("Verbose")]
    Verbose,

    [Description("Warning")]
    Warning,
}
