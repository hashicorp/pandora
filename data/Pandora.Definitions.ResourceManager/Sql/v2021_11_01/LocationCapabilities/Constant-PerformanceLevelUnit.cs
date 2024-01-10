using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PerformanceLevelUnitConstant
{
    [Description("DTU")]
    DTU,

    [Description("VCores")]
    VCores,
}
