using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileTypeConstant
{
    [Description("Filestream")]
    Filestream,

    [Description("Fulltext")]
    Fulltext,

    [Description("Log")]
    Log,

    [Description("NotSupported")]
    NotSupported,

    [Description("Rows")]
    Rows,
}
