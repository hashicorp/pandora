using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingKindConstant
{
    [Description("Anomalies")]
    Anomalies,

    [Description("EntityAnalytics")]
    EntityAnalytics,

    [Description("EyesOn")]
    EyesOn,

    [Description("Ueba")]
    Ueba,
}
