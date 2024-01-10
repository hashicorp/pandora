using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_08_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectivityStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,

    [Description("NotConnectedRecently")]
    NotConnectedRecently,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("NotYetRegistered")]
    NotYetRegistered,

    [Description("PartiallyConnected")]
    PartiallyConnected,
}
