using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultSharePermissionConstant
{
    [Description("None")]
    None,

    [Description("StorageFileDataSmbShareContributor")]
    StorageFileDataSmbShareContributor,

    [Description("StorageFileDataSmbShareElevatedContributor")]
    StorageFileDataSmbShareElevatedContributor,

    [Description("StorageFileDataSmbShareOwner")]
    StorageFileDataSmbShareOwner,

    [Description("StorageFileDataSmbShareReader")]
    StorageFileDataSmbShareReader,
}
