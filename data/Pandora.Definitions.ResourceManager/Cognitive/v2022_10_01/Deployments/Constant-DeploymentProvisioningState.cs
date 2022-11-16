using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.Deployments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Moving")]
    Moving,

    [Description("Succeeded")]
    Succeeded,
}
