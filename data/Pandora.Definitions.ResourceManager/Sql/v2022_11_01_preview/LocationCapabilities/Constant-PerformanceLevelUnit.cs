using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PerformanceLevelUnitConstant
{
    [Description("DTU")]
    DTU,

    [Description("VCores")]
    VCores,
}
