using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyPermissionConstant
{
    [Description("Full")]
    Full,

    [Description("Read")]
    Read,
}
