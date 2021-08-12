using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PrivateEndpointServiceConnectionStatusConstant
    {
        [Description("Approved")]
        Approved,

        [Description("Pending")]
        Pending,

        [Description("Rejected")]
        Rejected,
    }
}
