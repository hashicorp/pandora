using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointTypeConstant
{
    [Description("AzureSubnet")]
    AzureSubnet,

    [Description("AzureVM")]
    AzureVM,

    [Description("AzureVNet")]
    AzureVNet,

    [Description("ExternalAddress")]
    ExternalAddress,

    [Description("MMAWorkspaceMachine")]
    MMAWorkspaceMachine,

    [Description("MMAWorkspaceNetwork")]
    MMAWorkspaceNetwork,
}
