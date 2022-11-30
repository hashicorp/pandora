using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssetContainerPermissionConstant
{
    [Description("Read")]
    Read,

    [Description("ReadWrite")]
    ReadWrite,

    [Description("ReadWriteDelete")]
    ReadWriteDelete,
}
