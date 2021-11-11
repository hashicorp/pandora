using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AlertTypeConstant
    {
        [Description("Budget")]
        Budget,

        [Description("BudgetForecast")]
        BudgetForecast,

        [Description("Credit")]
        Credit,

        [Description("General")]
        General,

        [Description("Invoice")]
        Invoice,

        [Description("Quota")]
        Quota,

        [Description("xCloud")]
        XCloud,
    }
}
