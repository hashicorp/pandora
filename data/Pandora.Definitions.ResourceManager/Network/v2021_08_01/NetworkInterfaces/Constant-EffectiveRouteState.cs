using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EffectiveRouteStateConstant
{
    [Description("Active")]
    Active,

    [Description("Invalid")]
    Invalid,
}
