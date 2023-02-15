using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiManagementServiceSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceSkuCapacityScaleTypeConstant
{
    [Description("automatic")]
    Automatic,

    [Description("manual")]
    Manual,

    [Description("none")]
    None,
}
