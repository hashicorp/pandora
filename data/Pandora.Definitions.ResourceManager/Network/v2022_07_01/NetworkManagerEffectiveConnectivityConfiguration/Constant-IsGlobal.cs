using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerEffectiveConnectivityConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsGlobalConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
