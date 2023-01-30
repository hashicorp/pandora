using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.AvailableSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuSignupOptionConstant
{
    [Description("Available")]
    Available,

    [Description("None")]
    None,
}
