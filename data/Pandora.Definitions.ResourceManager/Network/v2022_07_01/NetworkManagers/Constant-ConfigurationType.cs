using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationTypeConstant
{
    [Description("Connectivity")]
    Connectivity,

    [Description("SecurityAdmin")]
    SecurityAdmin,
}
