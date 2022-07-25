using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2021_06_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Create")]
    Create,

    [Description("Default")]
    Default,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Update")]
    Update,
}
