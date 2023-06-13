using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.LongTermRetentionBackups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LongTermRetentionDatabaseStateConstant
{
    [Description("All")]
    All,

    [Description("Deleted")]
    Deleted,

    [Description("Live")]
    Live,
}
