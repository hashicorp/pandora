using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterTrackPropertyTypeConstant
{
    [Description("Bitrate")]
    Bitrate,

    [Description("FourCC")]
    FourCC,

    [Description("Language")]
    Language,

    [Description("Name")]
    Name,

    [Description("Type")]
    Type,

    [Description("Unknown")]
    Unknown,
}
