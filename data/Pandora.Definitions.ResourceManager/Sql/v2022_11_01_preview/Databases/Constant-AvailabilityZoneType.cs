using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AvailabilityZoneTypeConstant
{
    [Description("NoPreference")]
    NoPreference,

    [Description("1")]
    One,

    [Description("3")]
    Three,

    [Description("2")]
    Two,
}
