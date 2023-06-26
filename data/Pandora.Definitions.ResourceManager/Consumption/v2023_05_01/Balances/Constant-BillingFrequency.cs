using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Balances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingFrequencyConstant
{
    [Description("Month")]
    Month,

    [Description("Quarter")]
    Quarter,

    [Description("Year")]
    Year,
}
