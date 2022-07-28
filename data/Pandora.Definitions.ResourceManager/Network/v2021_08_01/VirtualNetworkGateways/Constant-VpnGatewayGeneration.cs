using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnGatewayGenerationConstant
{
    [Description("Generation1")]
    GenerationOne,

    [Description("Generation2")]
    GenerationTwo,

    [Description("None")]
    None,
}
