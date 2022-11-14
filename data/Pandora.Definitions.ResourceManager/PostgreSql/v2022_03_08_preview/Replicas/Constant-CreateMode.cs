using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Create")]
    Create,

    [Description("Default")]
    Default,

    [Description("GeoRestore")]
    GeoRestore,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Replica")]
    Replica,

    [Description("Update")]
    Update,
}
