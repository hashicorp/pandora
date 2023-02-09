using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.StorageSyncServicesResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncomingTrafficPolicyConstant
{
    [Description("AllowAllTraffic")]
    AllowAllTraffic,

    [Description("AllowVirtualNetworksOnly")]
    AllowVirtualNetworksOnly,
}
