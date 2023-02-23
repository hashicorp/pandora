using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertDetailConstant
{
    [Description("DisplayName")]
    DisplayName,

    [Description("Severity")]
    Severity,
}
