using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkPeerings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkPeeringLevelConstant
{
    [Description("FullyInSync")]
    FullyInSync,

    [Description("LocalAndRemoteNotInSync")]
    LocalAndRemoteNotInSync,

    [Description("LocalNotInSync")]
    LocalNotInSync,

    [Description("RemoteNotInSync")]
    RemoteNotInSync,
}
