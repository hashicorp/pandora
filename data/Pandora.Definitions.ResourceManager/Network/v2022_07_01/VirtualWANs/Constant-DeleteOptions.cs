using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeleteOptionsConstant
{
    [Description("Delete")]
    Delete,

    [Description("Detach")]
    Detach,
}
