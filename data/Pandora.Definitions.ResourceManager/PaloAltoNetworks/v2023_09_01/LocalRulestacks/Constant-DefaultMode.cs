using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRulestacks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultModeConstant
{
    [Description("FIREWALL")]
    FIREWALL,

    [Description("IPS")]
    IPS,

    [Description("NONE")]
    NONE,
}
