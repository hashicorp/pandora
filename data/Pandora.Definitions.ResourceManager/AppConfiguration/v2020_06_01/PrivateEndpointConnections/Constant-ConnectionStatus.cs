using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateEndpointConnections
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ConnectionStatusConstant
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
