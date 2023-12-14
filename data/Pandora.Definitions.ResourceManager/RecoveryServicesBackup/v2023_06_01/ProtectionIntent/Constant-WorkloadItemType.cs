using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.ProtectionIntent;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkloadItemTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("SAPAseDatabase")]
    SAPAseDatabase,

    [Description("SAPAseSystem")]
    SAPAseSystem,

    [Description("SAPHanaDBInstance")]
    SAPHanaDBInstance,

    [Description("SAPHanaDatabase")]
    SAPHanaDatabase,

    [Description("SAPHanaSystem")]
    SAPHanaSystem,

    [Description("SQLDataBase")]
    SQLDataBase,

    [Description("SQLInstance")]
    SQLInstance,
}
