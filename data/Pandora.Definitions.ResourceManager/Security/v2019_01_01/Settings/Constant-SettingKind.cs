using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingKindConstant
{
    [Description("AlertSuppressionSetting")]
    AlertSuppressionSetting,

    [Description("DataExportSettings")]
    DataExportSettings,
}
