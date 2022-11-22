using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.Incidents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentClassificationReasonConstant
{
    [Description("InaccurateData")]
    InaccurateData,

    [Description("IncorrectAlertLogic")]
    IncorrectAlertLogic,

    [Description("SuspiciousActivity")]
    SuspiciousActivity,

    [Description("SuspiciousButExpected")]
    SuspiciousButExpected,
}
