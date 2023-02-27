using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkRuleBypassOptionsConstant
{
    [Description("AzureServices")]
    AzureServices,

    [Description("None")]
    None,
}
