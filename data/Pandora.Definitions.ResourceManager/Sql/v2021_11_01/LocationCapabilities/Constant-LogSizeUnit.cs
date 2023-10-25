using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogSizeUnitConstant
{
    [Description("Gigabytes")]
    Gigabytes,

    [Description("Megabytes")]
    Megabytes,

    [Description("Percent")]
    Percent,

    [Description("Petabytes")]
    Petabytes,

    [Description("Terabytes")]
    Terabytes,
}
