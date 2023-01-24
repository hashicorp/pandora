using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.StandardOperation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceSkuCapacityScaleTypeConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Manual")]
    Manual,

    [Description("None")]
    None,
}
