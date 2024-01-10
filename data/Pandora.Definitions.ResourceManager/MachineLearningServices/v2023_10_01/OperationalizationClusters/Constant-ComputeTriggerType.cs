using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComputeTriggerTypeConstant
{
    [Description("Cron")]
    Cron,

    [Description("Recurrence")]
    Recurrence,
}
