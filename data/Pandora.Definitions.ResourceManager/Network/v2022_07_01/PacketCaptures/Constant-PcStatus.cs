using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PcStatusConstant
{
    [Description("Error")]
    Error,

    [Description("NotStarted")]
    NotStarted,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Unknown")]
    Unknown,
}
