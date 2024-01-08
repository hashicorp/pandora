using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewaySkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("ErGw1AZ")]
    ErGwOneAZ,

    [Description("ErGwScale")]
    ErGwScale,

    [Description("ErGw3AZ")]
    ErGwThreeAZ,

    [Description("ErGw2AZ")]
    ErGwTwoAZ,

    [Description("HighPerformance")]
    HighPerformance,

    [Description("Standard")]
    Standard,

    [Description("UltraPerformance")]
    UltraPerformance,

    [Description("VpnGw5")]
    VpnGwFive,

    [Description("VpnGw5AZ")]
    VpnGwFiveAZ,

    [Description("VpnGw4")]
    VpnGwFour,

    [Description("VpnGw4AZ")]
    VpnGwFourAZ,

    [Description("VpnGw1")]
    VpnGwOne,

    [Description("VpnGw1AZ")]
    VpnGwOneAZ,

    [Description("VpnGw3")]
    VpnGwThree,

    [Description("VpnGw3AZ")]
    VpnGwThreeAZ,

    [Description("VpnGw2")]
    VpnGwTwo,

    [Description("VpnGw2AZ")]
    VpnGwTwoAZ,
}
