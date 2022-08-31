using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleConstant
{
    [Description("PRIMARY")]
    PRIMARY,

    [Description("SECONDARY")]
    SECONDARY,
}
