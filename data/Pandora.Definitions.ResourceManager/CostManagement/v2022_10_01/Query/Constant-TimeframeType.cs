using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Query;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeframeTypeConstant
{
    [Description("BillingMonthToDate")]
    BillingMonthToDate,

    [Description("Custom")]
    Custom,

    [Description("MonthToDate")]
    MonthToDate,

    [Description("TheLastBillingMonth")]
    TheLastBillingMonth,

    [Description("TheLastMonth")]
    TheLastMonth,

    [Description("WeekToDate")]
    WeekToDate,
}
