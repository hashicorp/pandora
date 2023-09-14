using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaSyncStatusConstant
{
    [Description("Synchronized")]
    Synchronized,

    [Description("Unknown")]
    Unknown,

    [Description("Unsynchronized")]
    Unsynchronized,
}
