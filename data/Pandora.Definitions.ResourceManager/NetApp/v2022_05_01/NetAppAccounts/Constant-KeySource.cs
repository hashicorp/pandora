using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.NetAppAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Microsoft.KeyVault")]
    MicrosoftPointKeyVault,

    [Description("Microsoft.NetApp")]
    MicrosoftPointNetApp,
}
