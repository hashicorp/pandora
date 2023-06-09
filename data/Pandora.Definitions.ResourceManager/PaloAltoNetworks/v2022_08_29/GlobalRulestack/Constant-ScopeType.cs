using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.GlobalRulestack;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeTypeConstant
{
    [Description("GLOBAL")]
    GLOBAL,

    [Description("LOCAL")]
    LOCAL,
}
