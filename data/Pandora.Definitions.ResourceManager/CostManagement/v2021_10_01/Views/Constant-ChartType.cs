using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChartTypeConstant
{
    [Description("Area")]
    Area,

    [Description("GroupedColumn")]
    GroupedColumn,

    [Description("Line")]
    Line,

    [Description("StackedColumn")]
    StackedColumn,

    [Description("Table")]
    Table,
}
