using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PeeringStateConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,

    [Description("Initiated")]
    Initiated,
}
