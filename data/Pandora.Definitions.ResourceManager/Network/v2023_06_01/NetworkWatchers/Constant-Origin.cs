using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OriginConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Local")]
    Local,

    [Description("Outbound")]
    Outbound,
}
