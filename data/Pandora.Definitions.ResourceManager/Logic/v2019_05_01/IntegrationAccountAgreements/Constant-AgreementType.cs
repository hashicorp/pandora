using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgreementTypeConstant
{
    [Description("AS2")]
    ASTwo,

    [Description("Edifact")]
    Edifact,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("X12")]
    XOneTwo,
}
