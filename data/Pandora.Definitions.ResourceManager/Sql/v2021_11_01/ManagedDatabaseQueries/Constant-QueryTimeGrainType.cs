using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabaseQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryTimeGrainTypeConstant
{
    [Description("P1D")]
    POneD,

    [Description("PT1H")]
    PTOneH,
}
