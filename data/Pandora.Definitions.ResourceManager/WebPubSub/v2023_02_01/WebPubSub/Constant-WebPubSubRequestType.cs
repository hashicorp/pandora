using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.WebPubSub.v2023_02_01.WebPubSub;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebPubSubRequestTypeConstant
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
