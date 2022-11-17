using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2022_05_01.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingKindConstant
{
    [Description("AlertSuppressionSetting")]
    AlertSuppressionSetting,

    [Description("AlertSyncSettings")]
    AlertSyncSettings,

    [Description("DataExportSettings")]
    DataExportSettings,
}
