using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DistributedAvailabilityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationModeConstant
{
    [Description("Async")]
    Async,

    [Description("Sync")]
    Sync,
}
