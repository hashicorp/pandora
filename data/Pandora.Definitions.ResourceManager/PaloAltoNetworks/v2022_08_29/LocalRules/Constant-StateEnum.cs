using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.LocalRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateEnumConstant
{
    [Description("DISABLED")]
    DISABLED,

    [Description("ENABLED")]
    ENABLED,
}
