using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RouteMapActionTypeConstant
{
    [Description("Add")]
    Add,

    [Description("Drop")]
    Drop,

    [Description("Remove")]
    Remove,

    [Description("Replace")]
    Replace,

    [Description("Unknown")]
    Unknown,
}
