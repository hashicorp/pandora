using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Budgets;

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

    [Description("Monthly")]
    Monthly,

    [Description("Quarterly")]
    Quarterly,
}
