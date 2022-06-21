using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Spacecraft;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolarizationConstant
{
    [Description("LHCP")]
    LHCP,

    [Description("linearHorizontal")]
    LinearHorizontal,

    [Description("linearVertical")]
    LinearVertical,

    [Description("RHCP")]
    RHCP,
}
