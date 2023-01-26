using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
