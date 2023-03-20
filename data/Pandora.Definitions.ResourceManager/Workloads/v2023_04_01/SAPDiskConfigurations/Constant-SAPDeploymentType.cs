using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDiskConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPDeploymentTypeConstant
{
    [Description("SingleServer")]
    SingleServer,

    [Description("ThreeTier")]
    ThreeTier,
}
