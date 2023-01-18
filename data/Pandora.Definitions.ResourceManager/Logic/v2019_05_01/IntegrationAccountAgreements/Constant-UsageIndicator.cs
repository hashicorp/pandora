using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsageIndicatorConstant
{
    [Description("Information")]
    Information,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Production")]
    Production,

    [Description("Test")]
    Test,
}
