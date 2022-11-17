using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Dismissed")]
    Dismissed,

    [Description("None")]
    None,

    [Description("Overridden")]
    Overridden,

    [Description("Resolved")]
    Resolved,
}
