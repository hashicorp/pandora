using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Deployments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentModeConstant
{
    [Description("Complete")]
    Complete,

    [Description("Incremental")]
    Incremental,
}
