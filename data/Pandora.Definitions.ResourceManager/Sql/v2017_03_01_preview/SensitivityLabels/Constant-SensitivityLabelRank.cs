using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.SensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityLabelRankConstant
{
    [Description("Critical")]
    Critical,

    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,

    [Description("None")]
    None,
}
