using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateLinkServiceConnectionStatusConstant
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
