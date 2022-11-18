using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingUpgradeModeConstant
{
    [Description("Monitored")]
    Monitored,

    [Description("UnmonitoredAuto")]
    UnmonitoredAuto,
}
