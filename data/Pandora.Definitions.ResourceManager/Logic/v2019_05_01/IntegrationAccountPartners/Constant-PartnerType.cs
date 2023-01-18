using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountPartners;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PartnerTypeConstant
{
    [Description("B2B")]
    BTwoB,

    [Description("NotSpecified")]
    NotSpecified,
}
