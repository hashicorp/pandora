using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointTypeConstant
{
    [Description("AzureArcVM")]
    AzureArcVM,

    [Description("AzureSubnet")]
    AzureSubnet,

    [Description("AzureVM")]
    AzureVM,

    [Description("AzureVMSS")]
    AzureVMSS,

    [Description("AzureVNet")]
    AzureVNet,

    [Description("ExternalAddress")]
    ExternalAddress,

    [Description("MMAWorkspaceMachine")]
    MMAWorkspaceMachine,

    [Description("MMAWorkspaceNetwork")]
    MMAWorkspaceNetwork,
}
