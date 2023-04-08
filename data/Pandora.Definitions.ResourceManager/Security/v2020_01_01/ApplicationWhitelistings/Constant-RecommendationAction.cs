using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationActionConstant
{
    [Description("Add")]
    Add,

    [Description("Recommended")]
    Recommended,

    [Description("Remove")]
    Remove,
}
