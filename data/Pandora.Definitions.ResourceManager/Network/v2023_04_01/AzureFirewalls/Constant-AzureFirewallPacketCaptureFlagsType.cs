using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.AzureFirewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFirewallPacketCaptureFlagsTypeConstant
{
    [Description("ack")]
    Ack,

    [Description("fin")]
    Fin,

    [Description("push")]
    Push,

    [Description("rst")]
    Rst,

    [Description("syn")]
    Syn,

    [Description("urg")]
    Urg,
}
