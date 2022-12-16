using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RefreshTypeConstant
{
    [Description("RefreshPeriodicallyWithDelta")]
    RefreshPeriodicallyWithDelta,

    [Description("RefreshPeriodicallyWithFull")]
    RefreshPeriodicallyWithFull,

    [Description("Static")]
    Static,
}
