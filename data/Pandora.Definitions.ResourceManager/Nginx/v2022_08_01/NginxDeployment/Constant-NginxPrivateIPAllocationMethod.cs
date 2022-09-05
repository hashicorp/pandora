using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NginxPrivateIPAllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
