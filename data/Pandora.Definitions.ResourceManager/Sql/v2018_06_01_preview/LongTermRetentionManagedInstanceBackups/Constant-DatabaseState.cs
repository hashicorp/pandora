using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.LongTermRetentionManagedInstanceBackups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabaseStateConstant
{
    [Description("All")]
    All,

    [Description("Deleted")]
    Deleted,

    [Description("Live")]
    Live,
}
