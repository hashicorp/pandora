using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallManagedRuleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionTypeConstant
{
    [Description("Allow")]
    Allow,

    [Description("Block")]
    Block,

    [Description("Log")]
    Log,

    [Description("Redirect")]
    Redirect,
}
