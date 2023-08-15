using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.UsageDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetrictypeConstant
{
    [Description("actualcost")]
    Actualcost,

    [Description("amortizedcost")]
    Amortizedcost,

    [Description("usage")]
    Usage,
}
