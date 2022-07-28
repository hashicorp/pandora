using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworks;

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
