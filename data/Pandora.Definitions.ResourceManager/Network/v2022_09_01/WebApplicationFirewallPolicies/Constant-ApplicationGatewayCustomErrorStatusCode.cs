using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayCustomErrorStatusCodeConstant
{
    [Description("HttpStatus500")]
    HTTPStatusFiveHundred,

    [Description("HttpStatus504")]
    HTTPStatusFiveZeroFour,

    [Description("HttpStatus503")]
    HTTPStatusFiveZeroThree,

    [Description("HttpStatus502")]
    HTTPStatusFiveZeroTwo,

    [Description("HttpStatus400")]
    HTTPStatusFourHundred,

    [Description("HttpStatus499")]
    HTTPStatusFourNineNine,

    [Description("HttpStatus408")]
    HTTPStatusFourZeroEight,

    [Description("HttpStatus405")]
    HTTPStatusFourZeroFive,

    [Description("HttpStatus404")]
    HTTPStatusFourZeroFour,

    [Description("HttpStatus403")]
    HTTPStatusFourZeroThree,
}
