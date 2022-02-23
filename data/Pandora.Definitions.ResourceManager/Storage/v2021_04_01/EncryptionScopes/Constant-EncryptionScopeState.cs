using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.EncryptionScopes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionScopeStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
