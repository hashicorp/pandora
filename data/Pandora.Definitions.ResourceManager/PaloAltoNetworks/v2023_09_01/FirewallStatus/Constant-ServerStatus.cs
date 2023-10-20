using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.FirewallStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerStatusConstant
{
    [Description("DOWN")]
    DOWN,

    [Description("UP")]
    UP,
}
