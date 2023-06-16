using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.ProtectionIntent;

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

    [Description("SAPHanaDBInstance")]
    SAPHanaDBInstance,

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
