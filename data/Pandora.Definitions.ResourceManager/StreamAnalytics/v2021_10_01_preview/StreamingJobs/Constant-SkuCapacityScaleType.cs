using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuCapacityScaleTypeConstant
{
    [Description("automatic")]
    Automatic,

    [Description("manual")]
    Manual,

    [Description("none")]
    None,
}
