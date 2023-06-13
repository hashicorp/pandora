using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseColumns;

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
