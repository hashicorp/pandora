using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RouteMapMatchConditionConstant
{
    [Description("Contains")]
    Contains,

    [Description("Equals")]
    Equals,

    [Description("NotContains")]
    NotContains,

    [Description("NotEquals")]
    NotEquals,

    [Description("Unknown")]
    Unknown,
}
