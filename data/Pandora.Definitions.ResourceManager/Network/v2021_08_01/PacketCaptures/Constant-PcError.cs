using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PcErrorConstant
{
    [Description("AgentStopped")]
    AgentStopped,

    [Description("CaptureFailed")]
    CaptureFailed,

    [Description("InternalError")]
    InternalError,

    [Description("LocalFileFailed")]
    LocalFileFailed,

    [Description("StorageFailed")]
    StorageFailed,
}
