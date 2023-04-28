using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.RouteTables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityRuleAccessConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
