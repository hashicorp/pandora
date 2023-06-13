using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityLabelUpdateKindConstant
{
    [Description("remove")]
    Remove,

    [Description("set")]
    Set,
}
