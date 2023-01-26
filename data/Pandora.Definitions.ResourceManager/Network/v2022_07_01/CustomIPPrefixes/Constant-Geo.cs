using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.CustomIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoConstant
{
    [Description("AFRI")]
    AFRI,

    [Description("APAC")]
    APAC,

    [Description("AQ")]
    AQ,

    [Description("EURO")]
    EURO,

    [Description("GLOBAL")]
    GLOBAL,

    [Description("LATAM")]
    LATAM,

    [Description("ME")]
    ME,

    [Description("NAM")]
    NAM,

    [Description("OCEANIA")]
    OCEANIA,
}
