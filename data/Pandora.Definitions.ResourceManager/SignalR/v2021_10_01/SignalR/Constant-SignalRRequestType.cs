using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignalRRequestTypeConstant
{
    [Description("ClientConnection")]
    ClientConnection,

    [Description("RESTAPI")]
    RESTAPI,

    [Description("ServerConnection")]
    ServerConnection,

    [Description("Trace")]
    Trace,
}
