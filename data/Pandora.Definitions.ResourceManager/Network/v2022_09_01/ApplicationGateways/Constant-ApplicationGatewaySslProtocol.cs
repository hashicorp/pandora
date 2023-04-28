using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySslProtocolConstant
{
    [Description("TLSv1_1")]
    TLSvOneOne,

    [Description("TLSv1_3")]
    TLSvOneThree,

    [Description("TLSv1_2")]
    TLSvOneTwo,

    [Description("TLSv1_0")]
    TLSvOneZero,
}
