using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2022_09_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AadAuthFailureModeConstant
{
    [Description("http401WithBearerChallenge")]
    HTTPFourZeroOneWithBearerChallenge,

    [Description("http403")]
    HTTPFourZeroThree,
}
