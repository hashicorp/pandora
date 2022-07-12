using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.DiskAccesses;

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
