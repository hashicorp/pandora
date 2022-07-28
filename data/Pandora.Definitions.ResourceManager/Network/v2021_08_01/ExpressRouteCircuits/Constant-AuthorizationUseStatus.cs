using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationUseStatusConstant
{
    [Description("Available")]
    Available,

    [Description("InUse")]
    InUse,
}
