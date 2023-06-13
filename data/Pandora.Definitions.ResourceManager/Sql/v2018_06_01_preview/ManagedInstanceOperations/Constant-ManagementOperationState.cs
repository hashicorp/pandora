using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstanceOperations;

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
