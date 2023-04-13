using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.DeploymentOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningOperationConstant
{
    [Description("Action")]
    Action,

    [Description("AzureAsyncOperationWaiting")]
    AzureAsyncOperationWaiting,

    [Description("Create")]
    Create,

    [Description("Delete")]
    Delete,

    [Description("DeploymentCleanup")]
    DeploymentCleanup,

    [Description("EvaluateDeploymentOutput")]
    EvaluateDeploymentOutput,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Read")]
    Read,

    [Description("ResourceCacheWaiting")]
    ResourceCacheWaiting,

    [Description("Waiting")]
    Waiting,
}
