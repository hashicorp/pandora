using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SCSIControllerTypeConstant
{
    [Description("buslogic")]
    Buslogic,

    [Description("lsilogic")]
    Lsilogic,

    [Description("lsilogicsas")]
    Lsilogicsas,

    [Description("pvscsi")]
    Pvscsi,
}
