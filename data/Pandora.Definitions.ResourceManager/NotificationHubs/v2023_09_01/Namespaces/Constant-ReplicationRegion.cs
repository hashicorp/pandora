using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRegionConstant
{
    [Description("AustraliaEast")]
    AustraliaEast,

    [Description("BrazilSouth")]
    BrazilSouth,

    [Description("Default")]
    Default,

    [Description("None")]
    None,

    [Description("NorthEurope")]
    NorthEurope,

    [Description("SouthAfricaNorth")]
    SouthAfricaNorth,

    [Description("SouthEastAsia")]
    SouthEastAsia,

    [Description("WestUs2")]
    WestUsTwo,
}
