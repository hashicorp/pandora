using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.PUT;

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
