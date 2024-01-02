using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggersOnConstant
{
    [Description("Alerts")]
    Alerts,

    [Description("Incidents")]
    Incidents,
}
