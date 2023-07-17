using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.TagRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SendSubscriptionLogsStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
