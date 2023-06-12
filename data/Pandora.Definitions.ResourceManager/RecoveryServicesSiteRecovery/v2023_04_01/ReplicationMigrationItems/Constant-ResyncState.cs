using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResyncStateConstant
{
    [Description("None")]
    None,

    [Description("PreparedForResynchronization")]
    PreparedForResynchronization,

    [Description("StartedResynchronization")]
    StartedResynchronization,
}
