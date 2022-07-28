using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoutingStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("None")]
    None,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
