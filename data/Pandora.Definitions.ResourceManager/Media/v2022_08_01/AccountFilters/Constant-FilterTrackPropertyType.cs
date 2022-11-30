using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AccountFilters;

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
