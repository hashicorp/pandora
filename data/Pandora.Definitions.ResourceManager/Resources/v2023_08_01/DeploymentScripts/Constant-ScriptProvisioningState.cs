using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_08_01.DeploymentScripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Failed")]
    Failed,

    [Description("ProvisioningResources")]
    ProvisioningResources,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,
}
