using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.AvailableSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuVersionConstant
{
    [Description("Preview")]
    Preview,

    [Description("Stable")]
    Stable,
}
