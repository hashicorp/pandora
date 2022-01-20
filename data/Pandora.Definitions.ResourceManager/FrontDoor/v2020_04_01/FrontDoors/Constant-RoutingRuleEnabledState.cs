using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoutingRuleEnabledStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
