using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MessageFilterTypeConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,

    [Description("NotSpecified")]
    NotSpecified,
}
