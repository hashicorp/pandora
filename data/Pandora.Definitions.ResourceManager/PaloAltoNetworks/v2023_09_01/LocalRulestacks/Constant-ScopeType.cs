using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRulestacks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeTypeConstant
{
    [Description("GLOBAL")]
    GLOBAL,

    [Description("LOCAL")]
    LOCAL,
}
