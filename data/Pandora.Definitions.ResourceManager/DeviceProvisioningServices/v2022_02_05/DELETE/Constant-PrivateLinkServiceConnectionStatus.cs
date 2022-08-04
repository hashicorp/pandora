using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.DELETE;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateLinkServiceConnectionStatusConstant
{
    [Description("Approved")]
    Approved,

    [Description("Disconnected")]
    Disconnected,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,
}
