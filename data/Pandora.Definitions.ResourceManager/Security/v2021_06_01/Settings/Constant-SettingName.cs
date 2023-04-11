using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingNameConstant
{
    [Description("MCAS")]
    MCAS,

    [Description("Sentinel")]
    Sentinel,

    [Description("WDATP")]
    WDATP,
}
