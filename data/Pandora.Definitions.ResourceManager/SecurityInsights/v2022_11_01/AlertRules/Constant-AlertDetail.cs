using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertDetailConstant
{
    [Description("DisplayName")]
    DisplayName,

    [Description("Severity")]
    Severity,
}
