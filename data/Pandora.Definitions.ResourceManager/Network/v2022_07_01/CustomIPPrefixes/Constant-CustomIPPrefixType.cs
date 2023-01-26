using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.CustomIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomIPPrefixTypeConstant
{
    [Description("Child")]
    Child,

    [Description("Parent")]
    Parent,

    [Description("Singular")]
    Singular,
}
