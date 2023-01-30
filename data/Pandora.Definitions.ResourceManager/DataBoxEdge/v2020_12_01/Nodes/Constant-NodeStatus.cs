using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Nodes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeStatusConstant
{
    [Description("Down")]
    Down,

    [Description("Rebooting")]
    Rebooting,

    [Description("ShuttingDown")]
    ShuttingDown,

    [Description("Unknown")]
    Unknown,

    [Description("Up")]
    Up,
}
