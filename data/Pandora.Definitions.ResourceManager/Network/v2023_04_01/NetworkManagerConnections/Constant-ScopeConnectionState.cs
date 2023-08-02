using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.NetworkManagerConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeConnectionStateConstant
{
    [Description("Conflict")]
    Conflict,

    [Description("Connected")]
    Connected,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,

    [Description("Revoked")]
    Revoked,
}
