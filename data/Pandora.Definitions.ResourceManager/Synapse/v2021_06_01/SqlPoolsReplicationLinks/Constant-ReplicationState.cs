using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationStateConstant
{
    [Description("CATCH_UP")]
    CATCHUP,

    [Description("PENDING")]
    PENDING,

    [Description("SEEDING")]
    SEEDING,

    [Description("SUSPENDED")]
    SUSPENDED,
}
