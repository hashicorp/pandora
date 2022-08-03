using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricStatisticTypeConstant
{
    [Description("Average")]
    Average,

    [Description("Count")]
    Count,

    [Description("Max")]
    Max,

    [Description("Min")]
    Min,

    [Description("Sum")]
    Sum,
}
