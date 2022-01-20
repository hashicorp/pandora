using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Zones;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ZoneTypeConstant
{
    [Description("Private")]
    Private,

    [Description("Public")]
    Public,
}
