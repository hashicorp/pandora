using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LongTermRetentionBackup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExecutionStatusConstant
{
    [Description("Cancelled")]
    Cancelled,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,
}
