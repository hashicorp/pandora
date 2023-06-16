using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2023_07_01.Deviceupdates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleConstant
{
    [Description("Failover")]
    Failover,

    [Description("Primary")]
    Primary,
}
