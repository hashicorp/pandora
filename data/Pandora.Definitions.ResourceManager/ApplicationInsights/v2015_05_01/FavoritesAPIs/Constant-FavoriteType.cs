using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.FavoritesAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FavoriteTypeConstant
{
    [Description("shared")]
    Shared,

    [Description("user")]
    User,
}
