using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2022_05_01.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingNameConstant
{
    [Description("MCAS")]
    MCAS,

    [Description("Sentinel")]
    Sentinel,

    [Description("WDATP")]
    WDATP,

    [Description("WDATP_EXCLUDE_LINUX_PUBLIC_PREVIEW")]
    WDATPEXCLUDELINUXPUBLICPREVIEW,

    [Description("WDATP_UNIFIED_SOLUTION")]
    WDATPUNIFIEDSOLUTION,
}
