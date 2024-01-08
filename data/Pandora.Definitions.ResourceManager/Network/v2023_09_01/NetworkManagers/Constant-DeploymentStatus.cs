using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkManagers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentStatusConstant
{
    [Description("Deployed")]
    Deployed,

    [Description("Deploying")]
    Deploying,

    [Description("Failed")]
    Failed,

    [Description("NotStarted")]
    NotStarted,
}
