using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Default")]
    Default,

    [Description("GeoRestore")]
    GeoRestore,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Replica")]
    Replica,
}
