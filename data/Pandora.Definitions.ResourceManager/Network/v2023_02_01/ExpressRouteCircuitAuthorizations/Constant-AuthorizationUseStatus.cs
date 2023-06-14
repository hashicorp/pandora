using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ExpressRouteCircuitAuthorizations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationUseStatusConstant
{
    [Description("Available")]
    Available,

    [Description("InUse")]
    InUse,
}
