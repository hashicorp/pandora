using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_08_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StandardTierStorageRedundancyConstant
{
    [Description("GeoRedundant")]
    GeoRedundant,

    [Description("Invalid")]
    Invalid,

    [Description("LocallyRedundant")]
    LocallyRedundant,

    [Description("ZoneRedundant")]
    ZoneRedundant,
}
