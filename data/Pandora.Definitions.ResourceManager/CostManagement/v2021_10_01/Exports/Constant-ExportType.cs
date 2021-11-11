using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ExportTypeConstant
    {
        [Description("ActualCost")]
        ActualCost,

        [Description("AmortizedCost")]
        AmortizedCost,

        [Description("Usage")]
        Usage,
    }
}
