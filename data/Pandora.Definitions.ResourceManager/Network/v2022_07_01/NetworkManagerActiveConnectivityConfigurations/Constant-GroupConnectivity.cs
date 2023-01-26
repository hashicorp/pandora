using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerActiveConnectivityConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupConnectivityConstant
{
    [Description("DirectlyConnected")]
    DirectlyConnected,

    [Description("None")]
    None,
}
