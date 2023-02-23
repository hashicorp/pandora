using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Incidents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentLabelTypeConstant
{
    [Description("AutoAssigned")]
    AutoAssigned,

    [Description("User")]
    User,
}
