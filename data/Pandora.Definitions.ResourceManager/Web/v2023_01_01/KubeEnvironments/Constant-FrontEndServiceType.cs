using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.KubeEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FrontEndServiceTypeConstant
{
    [Description("LoadBalancer")]
    LoadBalancer,

    [Description("NodePort")]
    NodePort,
}
