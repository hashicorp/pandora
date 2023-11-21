using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SmartGroupsSortByFieldsConstant
{
    [Description("alertsCount")]
    AlertsCount,

    [Description("lastModifiedDateTime")]
    LastModifiedDateTime,

    [Description("severity")]
    Severity,

    [Description("startDateTime")]
    StartDateTime,

    [Description("state")]
    State,
}
