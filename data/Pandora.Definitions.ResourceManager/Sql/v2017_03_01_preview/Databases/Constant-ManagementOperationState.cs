using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.Databases;

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
