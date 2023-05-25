using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseAutomaticTuning;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomaticTuningOptionModeActualConstant
{
    [Description("Off")]
    Off,

    [Description("On")]
    On,
}
