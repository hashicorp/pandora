using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyModeConstant
{
    [Description("Detection")]
    Detection,

    [Description("Prevention")]
    Prevention,
}
