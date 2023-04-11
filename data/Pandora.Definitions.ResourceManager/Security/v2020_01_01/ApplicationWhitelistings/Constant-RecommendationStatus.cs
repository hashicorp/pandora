using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationStatusConstant
{
    [Description("NoStatus")]
    NoStatus,

    [Description("NotAvailable")]
    NotAvailable,

    [Description("NotRecommended")]
    NotRecommended,

    [Description("Recommended")]
    Recommended,
}
