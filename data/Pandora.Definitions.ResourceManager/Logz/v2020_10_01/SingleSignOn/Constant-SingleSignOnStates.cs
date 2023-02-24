using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SingleSignOn;

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
