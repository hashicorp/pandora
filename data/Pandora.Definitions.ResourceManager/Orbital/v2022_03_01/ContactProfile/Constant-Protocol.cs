using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,
}
