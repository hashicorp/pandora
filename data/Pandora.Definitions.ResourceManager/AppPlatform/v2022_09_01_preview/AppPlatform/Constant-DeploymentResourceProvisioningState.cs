using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentResourceProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
