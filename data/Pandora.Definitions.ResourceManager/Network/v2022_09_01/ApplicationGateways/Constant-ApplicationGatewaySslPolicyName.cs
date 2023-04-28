using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySslPolicyNameConstant
{
    [Description("AppGwSslPolicy20150501")]
    AppGwSslPolicyTwoZeroOneFiveZeroFiveZeroOne,

    [Description("AppGwSslPolicy20170401")]
    AppGwSslPolicyTwoZeroOneSevenZeroFourZeroOne,

    [Description("AppGwSslPolicy20170401S")]
    AppGwSslPolicyTwoZeroOneSevenZeroFourZeroOneS,

    [Description("AppGwSslPolicy20220101")]
    AppGwSslPolicyTwoZeroTwoTwoZeroOneZeroOne,

    [Description("AppGwSslPolicy20220101S")]
    AppGwSslPolicyTwoZeroTwoTwoZeroOneZeroOneS,
}
