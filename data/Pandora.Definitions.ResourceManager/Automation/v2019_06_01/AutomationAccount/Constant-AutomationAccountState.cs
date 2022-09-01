using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.AutomationAccount;

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
