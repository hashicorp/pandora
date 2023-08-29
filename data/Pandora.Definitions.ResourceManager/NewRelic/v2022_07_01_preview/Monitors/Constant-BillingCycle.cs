using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01_preview.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingCycleConstant
{
    [Description("MONTHLY")]
    MONTHLY,

    [Description("WEEKLY")]
    WEEKLY,

    [Description("YEARLY")]
    YEARLY,
}
