using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;

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
