using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCrossConnectionPeerings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant
{
    [Description("Configured")]
    Configured,

    [Description("Configuring")]
    Configuring,

    [Description("NotConfigured")]
    NotConfigured,

    [Description("ValidationNeeded")]
    ValidationNeeded,
}
