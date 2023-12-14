using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VaultListFilterTypesConstant
{
    [Description("resourceType eq 'Microsoft.KeyVault/vaults'")]
    ResourceTypeEqMicrosoftPointKeyVaultVaults,
}
