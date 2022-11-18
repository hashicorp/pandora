using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Deployments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentModeConstant
{
    [Description("Complete")]
    Complete,

    [Description("Incremental")]
    Incremental,
}
