using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertTimeGrainTypeConstant
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

    [Description("None")]
    None,

    [Description("Quarterly")]
    Quarterly,
}
