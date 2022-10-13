using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.EncryptionScopes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionScopeSourceConstant
{
    [Description("Microsoft.KeyVault")]
    MicrosoftPointKeyVault,

    [Description("Microsoft.Storage")]
    MicrosoftPointStorage,
}
