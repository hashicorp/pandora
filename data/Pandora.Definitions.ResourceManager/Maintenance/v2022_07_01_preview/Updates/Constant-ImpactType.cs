using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.Updates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImpactTypeConstant
{
    [Description("Freeze")]
    Freeze,

    [Description("None")]
    None,

    [Description("Redeploy")]
    Redeploy,

    [Description("Restart")]
    Restart,
}
