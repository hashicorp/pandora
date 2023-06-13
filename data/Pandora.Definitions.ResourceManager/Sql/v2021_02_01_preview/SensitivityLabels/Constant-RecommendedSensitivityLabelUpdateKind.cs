using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedSensitivityLabelUpdateKindConstant
{
    [Description("disable")]
    Disable,

    [Description("enable")]
    Enable,
}
