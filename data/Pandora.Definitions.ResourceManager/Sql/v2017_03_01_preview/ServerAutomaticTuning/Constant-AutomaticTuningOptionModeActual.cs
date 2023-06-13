using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.ServerAutomaticTuning;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomaticTuningOptionModeActualConstant
{
    [Description("Off")]
    Off,

    [Description("On")]
    On,
}
