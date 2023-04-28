using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkInterfaces;

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
