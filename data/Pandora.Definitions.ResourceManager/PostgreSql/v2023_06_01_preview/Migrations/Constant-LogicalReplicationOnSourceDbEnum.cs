using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogicalReplicationOnSourceDbEnumConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
