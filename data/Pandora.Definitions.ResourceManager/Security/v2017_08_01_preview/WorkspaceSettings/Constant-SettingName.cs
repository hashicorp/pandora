using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.WorkspaceSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingNameConstant
{
    [Description("MCAS")]
    MCAS,

    [Description("WDATP")]
    WDATP,
}
