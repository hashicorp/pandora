using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationDbStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Canceling")]
    Canceling,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,

    [Description("WaitingForCutoverTrigger")]
    WaitingForCutoverTrigger,
}
