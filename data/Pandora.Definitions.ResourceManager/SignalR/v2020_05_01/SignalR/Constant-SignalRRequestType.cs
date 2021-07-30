using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SignalRRequestType
    {
        [Description("ClientConnection")]
        ClientConnection,

        [Description("RESTAPI")]
        RESTAPI,

        [Description("ServerConnection")]
        ServerConnection,
    }
}
