using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DestinationPortBehaviorConstant
{
    [Description("ListenIfAvailable")]
    ListenIfAvailable,

    [Description("None")]
    None,
}
