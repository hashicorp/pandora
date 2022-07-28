using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LoadBalancers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadDistributionConstant
{
    [Description("Default")]
    Default,

    [Description("SourceIP")]
    SourceIP,

    [Description("SourceIPProtocol")]
    SourceIPProtocol,
}
