using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.LogAnalytics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntervalInMinsConstant
{
    [Description("FiveMins")]
    FiveMins,

    [Description("SixtyMins")]
    SixtyMins,

    [Description("ThirtyMins")]
    ThirtyMins,

    [Description("ThreeMins")]
    ThreeMins,
}
