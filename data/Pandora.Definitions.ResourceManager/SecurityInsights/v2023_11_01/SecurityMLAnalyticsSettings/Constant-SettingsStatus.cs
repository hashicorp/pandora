using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SecurityMLAnalyticsSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingsStatusConstant
{
    [Description("Flighting")]
    Flighting,

    [Description("Production")]
    Production,
}
