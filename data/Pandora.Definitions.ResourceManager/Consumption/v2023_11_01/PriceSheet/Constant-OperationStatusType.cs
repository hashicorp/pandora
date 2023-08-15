using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.PriceSheet;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusTypeConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,
}
