using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegionCategoryConstant
{
    [Description("Extended")]
    Extended,

    [Description("Other")]
    Other,

    [Description("Recommended")]
    Recommended,
}
