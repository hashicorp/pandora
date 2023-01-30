using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataBoxEdgeDeviceStatusConstant
{
    [Description("Disconnected")]
    Disconnected,

    [Description("Maintenance")]
    Maintenance,

    [Description("NeedsAttention")]
    NeedsAttention,

    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("PartiallyDisconnected")]
    PartiallyDisconnected,

    [Description("ReadyToSetup")]
    ReadyToSetup,
}
