using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayCustomErrorStatusCodeConstant
{
    [Description("HttpStatus502")]
    HttpStatusFiveZeroTwo,

    [Description("HttpStatus403")]
    HttpStatusFourZeroThree,
}
