using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2024_01_01.Pricings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourcesCoverageStatusConstant
{
    [Description("FullyCovered")]
    FullyCovered,

    [Description("NotCovered")]
    NotCovered,

    [Description("PartiallyCovered")]
    PartiallyCovered,
}
