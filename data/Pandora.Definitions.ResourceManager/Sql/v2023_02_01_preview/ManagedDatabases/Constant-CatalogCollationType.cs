using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CatalogCollationTypeConstant
{
    [Description("DATABASE_DEFAULT")]
    DATABASEDEFAULT,

    [Description("SQL_Latin1_General_CP1_CI_AS")]
    SQLLatinOneGeneralCPOneCIAS,
}
