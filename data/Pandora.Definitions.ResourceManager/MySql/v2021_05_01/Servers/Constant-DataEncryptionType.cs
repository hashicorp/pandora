using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataEncryptionTypeConstant
{
    [Description("AzureKeyVault")]
    AzureKeyVault,

    [Description("SystemManaged")]
    SystemManaged,
}
