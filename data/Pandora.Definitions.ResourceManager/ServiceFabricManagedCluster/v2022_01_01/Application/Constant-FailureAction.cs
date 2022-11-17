using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FailureActionConstant
{
    [Description("Manual")]
    Manual,

    [Description("Rollback")]
    Rollback,
}
