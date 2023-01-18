using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum X12CharacterSetConstant
{
    [Description("Basic")]
    Basic,

    [Description("Extended")]
    Extended,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("UTF8")]
    UTFEight,
}
