using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.VNetPeering;

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
