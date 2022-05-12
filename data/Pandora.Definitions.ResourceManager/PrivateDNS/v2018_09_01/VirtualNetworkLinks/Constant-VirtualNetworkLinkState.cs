using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.VirtualNetworkLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkLinkStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("InProgress")]
    InProgress,
}
