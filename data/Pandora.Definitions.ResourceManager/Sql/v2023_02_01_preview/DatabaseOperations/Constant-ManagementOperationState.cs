using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementOperationStateConstant
{
    [Description("CancelInProgress")]
    CancelInProgress,

    [Description("Cancelled")]
    Cancelled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,
}
