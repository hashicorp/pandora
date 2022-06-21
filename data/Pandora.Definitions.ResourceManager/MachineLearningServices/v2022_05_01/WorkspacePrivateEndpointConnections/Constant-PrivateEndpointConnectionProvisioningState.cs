using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.WorkspacePrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateEndpointConnectionProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
