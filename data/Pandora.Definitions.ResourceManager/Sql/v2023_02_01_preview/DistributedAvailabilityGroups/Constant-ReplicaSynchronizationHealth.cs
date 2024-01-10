using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DistributedAvailabilityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicaSynchronizationHealthConstant
{
    [Description("HEALTHY")]
    HEALTHY,

    [Description("NOT_HEALTHY")]
    NOTHEALTHY,

    [Description("PARTIALLY_HEALTHY")]
    PARTIALLYHEALTHY,
}
