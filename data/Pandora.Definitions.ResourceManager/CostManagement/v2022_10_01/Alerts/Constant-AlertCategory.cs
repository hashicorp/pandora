using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertCategoryConstant
{
    [Description("Billing")]
    Billing,

    [Description("Cost")]
    Cost,

    [Description("System")]
    System,

    [Description("Usage")]
    Usage,
}
