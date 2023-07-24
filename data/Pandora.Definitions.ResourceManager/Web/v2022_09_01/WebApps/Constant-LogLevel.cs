using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogLevelConstant
{
    [Description("Error")]
    Error,

    [Description("Information")]
    Information,

    [Description("Off")]
    Off,

    [Description("Verbose")]
    Verbose,

    [Description("Warning")]
    Warning,
}
