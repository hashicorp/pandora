using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeGrainTypeConstant
{
    [Description("Annually")]
    Annually,

    [Description("BillingAnnual")]
    BillingAnnual,

    [Description("BillingMonth")]
    BillingMonth,

    [Description("BillingQuarter")]
    BillingQuarter,

    [Description("Last7Days")]
    LastSevenDays,

    [Description("Last30Days")]
    LastThreeZeroDays,

    [Description("Monthly")]
    Monthly,

    [Description("Quarterly")]
    Quarterly,
}
