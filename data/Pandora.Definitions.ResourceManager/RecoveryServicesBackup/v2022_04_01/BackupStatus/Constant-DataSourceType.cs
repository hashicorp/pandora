using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSourceTypeConstant
{
    [Description("AzureFileShare")]
    AzureFileShare,

    [Description("AzureSqlDb")]
    AzureSqlDb,

    [Description("Client")]
    Client,

    [Description("Exchange")]
    Exchange,

    [Description("FileFolder")]
    FileFolder,

    [Description("GenericDataSource")]
    GenericDataSource,

    [Description("Invalid")]
    Invalid,

    [Description("SAPAseDatabase")]
    SAPAseDatabase,

    [Description("SAPHanaDatabase")]
    SAPHanaDatabase,

    [Description("SQLDB")]
    SQLDB,

    [Description("SQLDataBase")]
    SQLDataBase,

    [Description("Sharepoint")]
    Sharepoint,

    [Description("SystemState")]
    SystemState,

    [Description("VM")]
    VM,

    [Description("VMwareVM")]
    VMwareVM,
}
