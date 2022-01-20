using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingUpgradeModeConstant
{
    [Description("Monitored")]
    Monitored,

    [Description("UnmonitoredAuto")]
    UnmonitoredAuto,
}
