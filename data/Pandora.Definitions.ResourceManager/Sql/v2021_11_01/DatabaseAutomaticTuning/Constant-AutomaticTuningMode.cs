using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseAutomaticTuning;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomaticTuningModeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Custom")]
    Custom,

    [Description("Inherit")]
    Inherit,

    [Description("Unspecified")]
    Unspecified,
}
