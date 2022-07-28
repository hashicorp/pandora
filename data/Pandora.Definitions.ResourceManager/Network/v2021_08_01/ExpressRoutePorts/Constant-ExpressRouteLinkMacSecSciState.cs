using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRoutePorts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteLinkMacSecSciStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
