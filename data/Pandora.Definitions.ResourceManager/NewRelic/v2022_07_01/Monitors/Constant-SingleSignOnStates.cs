using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SingleSignOnStatesConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,

    [Description("Existing")]
    Existing,

    [Description("Initial")]
    Initial,
}
