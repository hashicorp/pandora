using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorTypeConstant
{
    [Description("EqualTo")]
    EqualTo,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqualTo")]
    GreaterThanOrEqualTo,
}
