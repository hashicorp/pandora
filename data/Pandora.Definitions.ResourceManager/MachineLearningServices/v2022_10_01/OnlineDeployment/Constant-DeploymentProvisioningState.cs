using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OnlineDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Scaling")]
    Scaling,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
