using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRoutePortAuthorizations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRoutePortAuthorizationUseStatusConstant
{
    [Description("Available")]
    Available,

    [Description("InUse")]
    InUse,
}
