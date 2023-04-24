using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2015_06_01.Agreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("Active")]
    Active,

    [Description("Canceled")]
    Canceled,
}
