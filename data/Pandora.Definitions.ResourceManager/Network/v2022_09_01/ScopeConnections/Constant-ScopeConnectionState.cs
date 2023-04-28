using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ScopeConnections;

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
