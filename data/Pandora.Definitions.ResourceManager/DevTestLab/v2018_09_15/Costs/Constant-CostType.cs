using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CostTypeConstant
{
    [Description("Projected")]
    Projected,

    [Description("Reported")]
    Reported,

    [Description("Unavailable")]
    Unavailable,
}
