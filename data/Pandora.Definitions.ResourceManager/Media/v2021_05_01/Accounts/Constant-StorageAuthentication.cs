using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_05_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAuthenticationConstant
{
    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("System")]
    System,
}
