using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationListFilterConstant
{
    [Description("Active")]
    Active,

    [Description("All")]
    All,
}
