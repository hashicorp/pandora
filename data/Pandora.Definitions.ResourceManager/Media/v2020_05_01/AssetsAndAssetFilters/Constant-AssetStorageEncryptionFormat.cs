using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssetStorageEncryptionFormatConstant
{
    [Description("MediaStorageClientEncryption")]
    MediaStorageClientEncryption,

    [Description("None")]
    None,
}
