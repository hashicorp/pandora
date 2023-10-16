using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PacketCaptureStatusConstant
{
    [Description("Error")]
    Error,

    [Description("NotStarted")]
    NotStarted,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,
}
