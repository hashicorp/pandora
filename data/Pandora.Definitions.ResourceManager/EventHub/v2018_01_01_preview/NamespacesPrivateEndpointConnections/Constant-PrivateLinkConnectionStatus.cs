using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PrivateLinkConnectionStatusConstant
    {
        [Description("Approved")]
        Approved,

        [Description("Disconnected")]
        Disconnected,

        [Description("Pending")]
        Pending,

        [Description("Rejected")]
        Rejected,
    }
}
