using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseTables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TableTemporalTypeConstant
{
    [Description("HistoryTable")]
    HistoryTable,

    [Description("NonTemporalTable")]
    NonTemporalTable,

    [Description("SystemVersionedTemporalTable")]
    SystemVersionedTemporalTable,
}
