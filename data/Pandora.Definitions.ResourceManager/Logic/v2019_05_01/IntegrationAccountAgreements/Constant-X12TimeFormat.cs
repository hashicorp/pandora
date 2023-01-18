using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum X12TimeFormatConstant
{
    [Description("HHMM")]
    HHMM,

    [Description("HHMMSS")]
    HHMMSS,

    [Description("HHMMSSd")]
    HHMMSSd,

    [Description("HHMMSSdd")]
    HHMMSSdd,

    [Description("NotSpecified")]
    NotSpecified,
}
