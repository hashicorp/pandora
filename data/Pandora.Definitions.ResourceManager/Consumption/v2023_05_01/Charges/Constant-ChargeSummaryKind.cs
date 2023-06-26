using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Charges;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChargeSummaryKindConstant
{
    [Description("legacy")]
    Legacy,

    [Description("modern")]
    Modern,
}
