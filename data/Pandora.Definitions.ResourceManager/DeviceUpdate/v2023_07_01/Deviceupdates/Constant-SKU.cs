using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2023_07_01.Deviceupdates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SKUConstant
{
    [Description("Free")]
    Free,

    [Description("Standard")]
    Standard,
}
