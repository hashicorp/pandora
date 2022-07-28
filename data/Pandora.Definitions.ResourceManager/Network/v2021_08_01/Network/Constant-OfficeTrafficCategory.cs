using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OfficeTrafficCategoryConstant
{
    [Description("All")]
    All,

    [Description("None")]
    None,

    [Description("Optimize")]
    Optimize,

    [Description("OptimizeAndAllow")]
    OptimizeAndAllow,
}
