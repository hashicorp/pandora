using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AddonFeaturesConstant
{
    [Description("BackupRestoreService")]
    BackupRestoreService,

    [Description("DnsService")]
    DnsService,

    [Description("ResourceMonitorService")]
    ResourceMonitorService,
}
