using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.Namespaces;

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
