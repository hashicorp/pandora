using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Microsoft.Keyvault")]
    MicrosoftPointKeyvault,

    [Description("Microsoft.Storage")]
    MicrosoftPointStorage,
}
