using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NumericalDataQualityMetricConstant
{
    [Description("DataTypeErrorRate")]
    DataTypeErrorRate,

    [Description("NullValueRate")]
    NullValueRate,

    [Description("OutOfBoundsRate")]
    OutOfBoundsRate,
}
