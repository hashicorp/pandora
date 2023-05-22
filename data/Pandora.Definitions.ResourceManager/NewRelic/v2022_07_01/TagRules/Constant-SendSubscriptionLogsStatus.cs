using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.TagRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SendSubscriptionLogsStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
