using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.GroundStation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReleaseModeConstant
{
    [Description("GA")]
    GA,

    [Description("Preview")]
    Preview,
}
