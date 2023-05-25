using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryMetricUnitTypeConstant
{
    [Description("count")]
    Count,

    [Description("KB")]
    KB,

    [Description("microseconds")]
    Microseconds,

    [Description("percentage")]
    Percentage,
}
