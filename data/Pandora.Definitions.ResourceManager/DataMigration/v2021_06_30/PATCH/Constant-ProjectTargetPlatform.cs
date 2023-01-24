using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.PATCH;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProjectTargetPlatformConstant
{
    [Description("AzureDbForMySql")]
    AzureDbForMySql,

    [Description("AzureDbForPostgreSql")]
    AzureDbForPostgreSql,

    [Description("MongoDb")]
    MongoDb,

    [Description("SQLDB")]
    SQLDB,

    [Description("SQLMI")]
    SQLMI,

    [Description("Unknown")]
    Unknown,
}
