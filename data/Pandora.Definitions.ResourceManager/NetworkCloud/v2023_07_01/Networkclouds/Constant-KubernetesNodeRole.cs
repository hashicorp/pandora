using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KubernetesNodeRoleConstant
{
    [Description("ControlPlane")]
    ControlPlane,

    [Description("Worker")]
    Worker,
}
