using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("BlobStorage")]
    BlobStorage,

    [Description("BlockBlobStorage")]
    BlockBlobStorage,

    [Description("FileStorage")]
    FileStorage,

    [Description("Storage")]
    Storage,

    [Description("StorageV2")]
    StorageVTwo,
}
