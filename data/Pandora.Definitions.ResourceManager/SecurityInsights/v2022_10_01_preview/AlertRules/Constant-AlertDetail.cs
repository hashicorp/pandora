using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertDetailConstant
{
    [Description("DisplayName")]
    DisplayName,

    [Description("Severity")]
    Severity,
}
