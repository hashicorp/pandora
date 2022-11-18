using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.EncryptionScopes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ListEncryptionScopesIncludeConstant
{
    [Description("All")]
    All,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
