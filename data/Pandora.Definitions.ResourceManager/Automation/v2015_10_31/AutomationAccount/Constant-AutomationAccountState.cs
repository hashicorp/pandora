using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationAccountStateConstant
{
    [Description("Ok")]
    Ok,

    [Description("Suspended")]
    Suspended,

    [Description("Unavailable")]
    Unavailable,
}
