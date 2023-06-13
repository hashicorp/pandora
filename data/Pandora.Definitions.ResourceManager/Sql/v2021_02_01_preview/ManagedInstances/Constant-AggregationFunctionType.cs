using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AggregationFunctionTypeConstant
{
    [Description("avg")]
    Avg,

    [Description("max")]
    Max,

    [Description("min")]
    Min,

    [Description("stdev")]
    Stdev,

    [Description("sum")]
    Sum,
}
