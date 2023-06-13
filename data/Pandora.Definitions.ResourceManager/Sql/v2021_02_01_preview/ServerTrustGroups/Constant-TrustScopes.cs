using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ServerTrustGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrustScopesConstant
{
    [Description("GlobalTransactions")]
    GlobalTransactions,

    [Description("ServiceBroker")]
    ServiceBroker,
}
