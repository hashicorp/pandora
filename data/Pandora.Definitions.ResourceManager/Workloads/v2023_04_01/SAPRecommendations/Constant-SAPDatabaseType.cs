using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPDatabaseTypeConstant
{
    [Description("DB2")]
    DBTwo,

    [Description("HANA")]
    HANA,
}
