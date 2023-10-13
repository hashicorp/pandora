using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.FavoritesAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FavoriteSourceTypeConstant
{
    [Description("events")]
    Events,

    [Description("funnel")]
    Funnel,

    [Description("impact")]
    Impact,

    [Description("notebook")]
    Notebook,

    [Description("retention")]
    Retention,

    [Description("segmentation")]
    Segmentation,

    [Description("sessions")]
    Sessions,

    [Description("userflows")]
    Userflows,
}
