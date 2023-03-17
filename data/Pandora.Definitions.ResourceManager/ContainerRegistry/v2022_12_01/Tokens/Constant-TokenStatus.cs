using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01.Tokens;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TokenStatusConstant
{
    [Description("disabled")]
    Disabled,

    [Description("enabled")]
    Enabled,
}
