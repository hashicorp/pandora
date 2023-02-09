using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageLimitExceededBehaviorConstant
{
    [Description("PauseIngress")]
    PauseIngress,

    [Description("PurgeOldData")]
    PurgeOldData,
}
