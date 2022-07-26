using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.SharedPrivateLinkResources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedPrivateLinkResourceStatusConstant
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
