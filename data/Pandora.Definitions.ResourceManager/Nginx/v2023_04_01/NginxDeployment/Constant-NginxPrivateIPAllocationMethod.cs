using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Nginx.v2023_04_01.NginxDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NginxPrivateIPAllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
