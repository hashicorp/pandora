using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlAvailabilityReplicaOverviewReplicaStateConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("Unknown")]
    Unknown,
}
