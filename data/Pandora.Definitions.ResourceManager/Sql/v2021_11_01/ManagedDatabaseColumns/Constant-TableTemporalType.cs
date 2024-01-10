using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabaseColumns;

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
