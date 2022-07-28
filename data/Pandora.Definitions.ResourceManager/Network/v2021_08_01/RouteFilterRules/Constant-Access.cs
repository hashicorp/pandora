using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.RouteFilterRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
