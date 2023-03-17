using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkRuleBypassOptionsConstant
{
    [Description("AzureServices")]
    AzureServices,

    [Description("None")]
    None,
}
