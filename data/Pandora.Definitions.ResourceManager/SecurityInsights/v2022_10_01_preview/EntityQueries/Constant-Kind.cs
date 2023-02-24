using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.EntityQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("Activity")]
    Activity,

    [Description("Expansion")]
    Expansion,
}
