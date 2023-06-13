using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.SensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityLabelSourceConstant
{
    [Description("current")]
    Current,

    [Description("recommended")]
    Recommended,
}
