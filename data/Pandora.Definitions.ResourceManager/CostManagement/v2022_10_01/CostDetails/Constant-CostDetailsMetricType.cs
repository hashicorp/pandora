using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.CostDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CostDetailsMetricTypeConstant
{
    [Description("ActualCost")]
    ActualCost,

    [Description("AmortizedCost")]
    AmortizedCost,
}
