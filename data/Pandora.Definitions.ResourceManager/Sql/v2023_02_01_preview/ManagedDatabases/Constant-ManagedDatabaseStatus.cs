using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDatabaseStatusConstant
{
    [Description("Creating")]
    Creating,

    [Description("DbCopying")]
    DbCopying,

    [Description("DbMoving")]
    DbMoving,

    [Description("Inaccessible")]
    Inaccessible,

    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("Restoring")]
    Restoring,

    [Description("Shutdown")]
    Shutdown,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Updating")]
    Updating,
}
