using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogModuleConstant
{
    [Description("DISABLED")]
    DISABLED,

    [Description("ENABLED")]
    ENABLED,
}
