using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MoveOperationModeConstant
{
    [Description("Copy")]
    Copy,

    [Description("Move")]
    Move,
}
