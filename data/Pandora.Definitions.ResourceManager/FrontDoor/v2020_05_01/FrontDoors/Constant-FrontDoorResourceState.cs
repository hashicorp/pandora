using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FrontDoorResourceStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Disabled")]
    Disabled,

    [Description("Disabling")]
    Disabling,

    [Description("Enabled")]
    Enabled,

    [Description("Enabling")]
    Enabling,
}
