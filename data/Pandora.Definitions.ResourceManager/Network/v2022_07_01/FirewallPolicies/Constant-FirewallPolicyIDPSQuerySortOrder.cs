using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyIDPSQuerySortOrderConstant
{
    [Description("Ascending")]
    Ascending,

    [Description("Descending")]
    Descending,
}
