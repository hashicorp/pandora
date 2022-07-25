using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2022_02_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedPrivateLinkResourceStatusConstant
{
    [Description("Approved")]
    Approved,

    [Description("Disconnected")]
    Disconnected,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,

    [Description("Timeout")]
    Timeout,
}
