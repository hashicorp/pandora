using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseMoveOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MoveOperationModeConstant
{
    [Description("Copy")]
    Copy,

    [Description("Move")]
    Move,
}
