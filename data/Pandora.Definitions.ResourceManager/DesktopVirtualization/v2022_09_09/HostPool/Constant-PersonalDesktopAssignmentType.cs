using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PersonalDesktopAssignmentTypeConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Direct")]
    Direct,
}
