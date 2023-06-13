using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseAutomaticTuning;

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
