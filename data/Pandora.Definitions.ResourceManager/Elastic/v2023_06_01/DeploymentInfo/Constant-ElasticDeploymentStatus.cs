using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.DeploymentInfo;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ElasticDeploymentStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("Unhealthy")]
    Unhealthy,
}
