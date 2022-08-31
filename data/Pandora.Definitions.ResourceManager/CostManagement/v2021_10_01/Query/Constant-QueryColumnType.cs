using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryColumnTypeConstant
{
    [Description("Dimension")]
    Dimension,

    [Description("Tag")]
    Tag,
}
