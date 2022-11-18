using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PivotTypeTypeConstant
{
    [Description("Dimension")]
    Dimension,

    [Description("TagKey")]
    TagKey,
}
