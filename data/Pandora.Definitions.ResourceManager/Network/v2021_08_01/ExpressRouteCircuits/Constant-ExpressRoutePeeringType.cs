using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRoutePeeringTypeConstant
{
    [Description("AzurePrivatePeering")]
    AzurePrivatePeering,

    [Description("AzurePublicPeering")]
    AzurePublicPeering,

    [Description("MicrosoftPeering")]
    MicrosoftPeering,
}
