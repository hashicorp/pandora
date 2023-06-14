using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkProfiles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancerBackendAddressAdminStateConstant
{
    [Description("Down")]
    Down,

    [Description("None")]
    None,

    [Description("Up")]
    Up,
}
