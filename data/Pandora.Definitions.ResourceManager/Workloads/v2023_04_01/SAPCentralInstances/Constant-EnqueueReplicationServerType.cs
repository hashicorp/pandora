using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPCentralInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnqueueReplicationServerTypeConstant
{
    [Description("EnqueueReplicator1")]
    EnqueueReplicatorOne,

    [Description("EnqueueReplicator2")]
    EnqueueReplicatorTwo,
}
