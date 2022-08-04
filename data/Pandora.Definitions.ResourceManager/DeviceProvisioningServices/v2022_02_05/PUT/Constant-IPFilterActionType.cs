using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PUT;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPFilterActionTypeConstant
{
    [Description("Accept")]
    Accept,

    [Description("Reject")]
    Reject,
}
