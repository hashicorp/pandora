using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySslPolicyNameConstant
{
    [Description("AppGwSslPolicy20150501")]
    AppGwSslPolicyTwoZeroOneFiveZeroFiveZeroOne,

    [Description("AppGwSslPolicy20170401")]
    AppGwSslPolicyTwoZeroOneSevenZeroFourZeroOne,

    [Description("AppGwSslPolicy20170401S")]
    AppGwSslPolicyTwoZeroOneSevenZeroFourZeroOneS,
}
