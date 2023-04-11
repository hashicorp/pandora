using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.Pricings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PricingTierConstant
{
    [Description("Free")]
    Free,

    [Description("Standard")]
    Standard,
}
