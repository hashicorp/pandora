using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2018_06_01.ResetQueryPerformanceInsightData;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryPerformanceInsightResetDataResultStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
