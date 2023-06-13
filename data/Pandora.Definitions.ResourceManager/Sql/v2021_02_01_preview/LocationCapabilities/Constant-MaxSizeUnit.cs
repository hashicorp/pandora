using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MaxSizeUnitConstant
{
    [Description("Gigabytes")]
    Gigabytes,

    [Description("Megabytes")]
    Megabytes,

    [Description("Petabytes")]
    Petabytes,

    [Description("Terabytes")]
    Terabytes,
}
