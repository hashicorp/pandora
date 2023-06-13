using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedDatabaseQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryTimeGrainTypeConstant
{
    [Description("P1D")]
    POneD,

    [Description("PT1H")]
    PTOneH,
}
