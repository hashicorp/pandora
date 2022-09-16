using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.BigDataPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeSizeConstant
{
    [Description("Large")]
    Large,

    [Description("Medium")]
    Medium,

    [Description("None")]
    None,

    [Description("Small")]
    Small,

    [Description("XLarge")]
    XLarge,

    [Description("XXLarge")]
    XXLarge,

    [Description("XXXLarge")]
    XXXLarge,
}
